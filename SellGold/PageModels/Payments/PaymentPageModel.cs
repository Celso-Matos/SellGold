using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Payments.Commands;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.Mappings.Payments;
using SellGold.Services.Payments.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SellGold.PageModels.Payments
{
    public class PaymentPageModel : ObservableObject
    {

            private readonly IMediator _mediator;
            private readonly IEnumerable<IBarcodeReader> _readers;

            public ObservableCollection<ProductResponse> Products { get; } = new();
            public ObservableCollection<string> FormasPagamento { get; } =
                new(new[] { "Dinheiro", "Cartão", "PIX" });

            private string _formaSelecionada = string.Empty;
            public string FormaSelecionada
            {
                get => _formaSelecionada;
                set => SetProperty(ref _formaSelecionada, value);
            }

            //public decimal Subtotal => Products.Sum(p => p.PrecoUnitario * p.Quantidade);
            public decimal Descontos { get; private set; }
            public decimal Impostos { get; private set; }
            //public decimal Total => Subtotal - Descontos + Impostos;

            // Commands
            public ICommand RemoverProdutoCommand { get; }
            public ICommand CancelarCompraCommand { get; }
            public ICommand AplicarCupomCommand { get; }
            public ICommand FinalizarVendaCommand { get; }
            public ICommand ConfirmarPagamentoCommand { get; }

            public PaymentPageModel(IEnumerable<IBarcodeReader> readers,
                                    IMediator mediator)
            {
                _readers = readers;
                _mediator = mediator;

                // Escuta todos os leitores registrados
                foreach (var reader in _readers)
                {
                    reader.BarcodeScanned += OnBarcodeScanned;
                    reader.StartListening();
                }

                //RemoverProdutoCommand = new Command<Products>(RemoverProduto);
                CancelarCompraCommand = new Command(CancelarCompra);
                AplicarCupomCommand = new Command(AplicarCupom);
                FinalizarVendaCommand = new Command(FinalizarVenda);
                ConfirmarPagamentoCommand = new Command(ConfirmarPagamento);
            }

            private void OnBarcodeScanned(object? sender, string barCode)
            {
                var product = SearchProduct(barCode);
                if (product != null)
                {
                    //OnPropertyChanged(nameof(Subtotal));
                    //OnPropertyChanged(nameof(Total));
                }
            }

            private async Task<ProductResponse?> SearchProduct(string barCode)
            {
                var product = await _mediator.Send(new ListGraphQLProductBarcodeQuery(barCode));
                
                if (product != null) 
                {                    
                    Products.Add(product);

                }
                return product;                   
            }

            private void RemoverProduto(ProductResponse Product)
            {
                if (Products.Contains(Product))
                {
                    Products.Remove(Product);
                    //OnPropertyChanged(nameof(Subtotal));
                    //OnPropertyChanged(nameof(Total));
                }
            }

            private void CancelarCompra()
            {
                Products.Clear();
                Descontos = 0;
                Impostos = 0;
                //OnPropertyChanged(nameof(Subtotal));
                //OnPropertyChanged(nameof(Total));
            }

            private void AplicarCupom()
            {
                Descontos = 5; // Exemplo fixo
                //OnPropertyChanged(nameof(Total));
            }

            private void FinalizarVenda()
            {
                // Lógica de fechamento da venda
            }

            private void ConfirmarPagamento()
            {
                // Lógica de integração com gateway de pagamento
            }
        }        
    
}
