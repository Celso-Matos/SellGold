Write-Host "🔴 Finalizando processos..."
Get-Process adb, java, dotnet -ErrorAction SilentlyContinue | Stop-Process -Force

Write-Host "🧹 Limpando bin/obj..."
Remove-Item -Recurse -Force bin, obj -ErrorAction SilentlyContinue

Write-Host "🧹 Limpando cache Android..."
Remove-Item -Recurse -Force "$env:USERPROFILE\.android\cache" -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force "$env:USERPROFILE\.android\build-cache" -ErrorAction SilentlyContinue

Write-Host "🧹 Limpando NuGet..."
dotnet nuget locals all --clear

Write-Host "🔧 Reparando workloads..."
dotnet workload repair

Write-Host "✅ Finalizado"

//Para Executar esse arquivo segue os comandos powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
.\clean-maui.ps1