–&
MC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Program.cs
var

 
builder

 
=

 
WebApplication

 
.

 
CreateBuilder

 *
(

* +
args

+ /
)

/ 0
;

0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
. 
AddNewtonsoftJson 
( 
options 
=> !
{ 
options 
. 
SerializerSettings "
." #!
ReferenceLoopHandling# 8
=9 :

Newtonsoft; E
.E F
JsonF J
.J K!
ReferenceLoopHandlingK `
.` a
Ignorea g
;g h
} 
) 
; 
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
	AddScoped 
< 
IPaymentsRepository .
,. /&
SellGoldPaymentsRepository0 J
>J K
(K L
)L M
;M N
builder 
. 
Services 
. 
AddDbContext 
< #
SellGoldPaymentsContext 5
>5 6
(6 7
options7 >
=>? A
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C
$strC _
)_ `
)` a
)a b
;b c
builder 
. 
Services 
. 
AddCors 
( 
options  
=>! #
{ 
options 
. 
	AddPolicy 
( 
$str  
,  !
policy   
=>   
policy   
.   
AllowAnyOrigin   '
(  ' (
)  ( )
.!! 
AllowAnyMethod!! '
(!!' (
)!!( )
."" 
AllowAnyHeader"" '
(""' (
)""( )
)"") *
;""* +
}## 
)## 
;## 
builder&& 
.&& 
Services&& 
.&& 

AddOpenApi&& 
(&& 
)&& 
;&& 
var)) 
app)) 
=)) 	
builder))
 
.)) 
Build)) 
()) 
))) 
;)) 
app,, 
.,, 
UseCors,, 
(,, 
$str,, 
),, 
;,, 
builder00 
.00 
Services00 
.00 
AddAutoMapper00 
(00 
cfg00 "
=>00# %
{11 
cfg22 
.22 

AddProfile22 
<22  
PaymentProfileMapper22 '
>22' (
(22( )
)22) *
;22* +
}33 
)33 
;33 
builder66 
.66 
Services66 
.66 

AddMediatR66 
(66 
typeof77 

(77
  
CreatePaymentHandler77 
)77  
.77  !
Assembly77! )
)88 
;88 
void<< 
ConfigureSwaggerUI<< 
(<< 
SwaggerUIOptions<< (
c<<) *
)<<* +
{== 
c>> 
.>> 
SwaggerEndpoint>> 
(>> 
$str>> 0
,>>0 1
$str>>2 K
)>>K L
;>>L M
c?? 
.?? 
RoutePrefix?? 
=?? 
$str?? 
;?? 
}@@ 
ifBB 
(BB 
appBB 
.BB 
EnvironmentBB 
.BB 
IsDevelopmentBB !
(BB! "
)BB" #
||BB$ &
appBB' *
.BB* +
EnvironmentBB+ 6
.BB6 7
	IsStagingBB7 @
(BB@ A
)BBA B
)BBB C
{CC 
appDD 
.DD 

UseSwaggerDD 
(DD 
)DD 
;DD 
appEE 
.EE 
UseSwaggerUIEE 
(EE 
ConfigureSwaggerUIEE '
)EE' (
;EE( )
}FF 
appHH 
.HH 
UseHttpsRedirectionHH 
(HH 
)HH 
;HH 
appII 
.II 
UseAuthorizationII 
(II 
)II 
;II 
appJJ 
.JJ 
MapControllersJJ 
(JJ 
)JJ 
;JJ 
awaitLL 
appLL 	
.LL	 

RunAsyncLL
 
(LL 
)LL 
;LL ∏ 
|C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Infrastructure\Repositories\SellGoldPaymentsRepository.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Infrastructure *
.* +
Repositories+ 7
{ 
public		 

class		 &
SellGoldPaymentsRepository		 +
:		, -
IPaymentsRepository		. A
{

 
private 
readonly #
SellGoldPaymentsContext 0
_context1 9
;9 :
public &
SellGoldPaymentsRepository )
() *#
SellGoldPaymentsContext* A
contextB I
)I J
{ 	
_context 
= 
context 
?? !
throw" '
new( +!
ArgumentNullException, A
(A B
nameofB H
(H I
contextI P
)P Q
)Q R
;R S
} 	
public 
async 
Task 
< 
Payment !
>! "
GetByIdAsync# /
(/ 0
Guid0 4
	paymentId5 >
)> ?
{ 	
return 
await 
_context !
.! "
Payments" *
.( )
FirstOrDefaultAsync) <
(< =
p= >
=>? A
pB C
.C D
	PaymentIdD M
==N P
	paymentIdQ Z
)Z [
??\ ^
throw_ d
newe h$
InfrastructureException	i Ä
(
Ä Å
$"
Å É
$str
É ç
{
ç é
	paymentId
é ó
}
ó ò
$str
ò ®
"
® ©
)
© ™
;
™ ´
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
Payment& -
>- .
>. /
GetAllAsync0 ;
(; <
)< =
{ 	
return 
await 
_context !
.! "
Payments" *
.* +
ToListAsync+ 6
(6 7
)7 8
;8 9
} 	
public 
async 
Task 
AddAsync "
(" #
Payment# *
payment+ 2
)2 3
{ 	
await 
_context 
. 
Payments #
.# $
AddAsync$ ,
(, -
payment- 4
)4 5
;5 6
await 
_context 
. 
SaveChangesAsync +
(+ ,
), -
;- .
} 	
public 
async 
Task 
UpdateAsync %
(% &
Payment& -
payment. 5
)5 6
{ 	
_context   
.   
Entry   
(   
payment   "
)  " #
.  # $
State  $ )
=  * +
EntityState  , 7
.  7 8
Modified  8 @
;  @ A
await!! 
_context!! 
.!! 
SaveChangesAsync!! +
(!!+ ,
)!!, -
;!!- .
}"" 	
public## 
async## 
Task## 
DeleteAsync## %
(##% &
Guid##& *
	paymentId##+ 4
)##4 5
{$$ 	
var%% 
payment%% 
=%% 
await%% 
_context%%  (
.%%( )
Payments%%) 1
.%%1 2
	FindAsync%%2 ;
(%%; <
	paymentId%%< E
)%%E F
;%%F G
if&& 
(&& 
payment&& 
!=&& 
null&& 
)&&  
{'' 
_context(( 
.(( 
Payments(( !
.((! "
Remove((" (
(((( )
payment(() 0
)((0 1
;((1 2
await)) 
_context)) 
.)) 
SaveChangesAsync)) /
())/ 0
)))0 1
;))1 2
}** 
}++ 	
},, 
}-- ñ
wC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Infrastructure\Exceptions\InfrastructureException.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Infrastructure *
.* +

Exceptions+ 5
{ 
public 

class #
InfrastructureException (
:) *
	Exception+ 4
{ 
public #
InfrastructureException &
(& '
string' -
message. 5
)5 6
: 
base 
( 
message 
) 
{ 	
} 	
public

 #
InfrastructureException

 &
(

& '
string

' -
message

. 5
,

5 6
	Exception

7 @
innerException

A O
)

O P
: 
base 
( 
message 
, 
innerException *
)* +
{ 	
} 	
} 
} ê
ÉC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Infrastructure\Data\Migrations\20251226204840_DomainUpdateNew.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Infrastructure *
.* +
Data+ /
./ 0

Migrations0 :
{ 
public 

partial 
class 
DomainUpdateNew (
:) *
	Migration+ 4
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
} 	
} 
} ä
ÄC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Infrastructure\Data\Migrations\20251226183312_DomainUpdate.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Infrastructure *
.* +
Data+ /
./ 0

Migrations0 :
{ 
public 

partial 
class 
DomainUpdate %
:& '
	Migration( 1
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
} 	
} 
} ÚP
ÅC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Infrastructure\Data\Migrations\20251224142426_InitialCreate.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Infrastructure *
.* +
Data+ /
./ 0

Migrations0 :
{ 
public		 

partial		 
class		 
InitialCreate		 &
:		' (
	Migration		) 2
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str %
,% &
columns 
: 
table 
=> !
new" %
{ 
PaymentMethodId #
=$ %
table& +
.+ ,
Column, 2
<2 3
Guid3 7
>7 8
(8 9
type9 =
:= >
$str? Q
,Q R
nullableS [
:[ \
false] b
)b c
,c d
PaymentMethodCode %
=& '
table( -
.- .
Column. 4
<4 5
string5 ;
>; <
(< =
type= A
:A B
$strC R
,R S
nullableT \
:\ ]
false^ c
)c d
,d e
PaymentMethodType %
=& '
table( -
.- .
Column. 4
<4 5
int5 8
>8 9
(9 :
type: >
:> ?
$str@ E
,E F
nullableG O
:O P
falseQ V
)V W
,W X!
SupportsAuthorization )
=* +
table, 1
.1 2
Column2 8
<8 9
bool9 =
>= >
(> ?
type? C
:C D
$strE J
,J K
nullableL T
:T U
falseV [
)[ \
,\ ]
SupportsCapture #
=$ %
table& +
.+ ,
Column, 2
<2 3
bool3 7
>7 8
(8 9
type9 =
:= >
$str? D
,D E
nullableF N
:N O
falseP U
)U V
,V W!
SupportsPartialRefund )
=* +
table, 1
.1 2
Column2 8
<8 9
bool9 =
>= >
(> ?
type? C
:C D
$strE J
,J K
nullableL T
:T U
falseV [
)[ \
,\ ]
IsActive 
= 
table $
.$ %
Column% +
<+ ,
bool, 0
>0 1
(1 2
type2 6
:6 7
$str8 =
,= >
nullable? G
:G H
falseI N
)N O
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 7
,7 8
x9 :
=>; =
x> ?
.? @
PaymentMethodId@ O
)O P
;P Q
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name   
:   
$str    
,    !
columns!! 
:!! 
table!! 
=>!! !
new!!" %
{"" 
	PaymentId## 
=## 
table##  %
.##% &
Column##& ,
<##, -
Guid##- 1
>##1 2
(##2 3
type##3 7
:##7 8
$str##9 K
,##K L
nullable##M U
:##U V
false##W \
)##\ ]
,##] ^
PaymentMethodId$$ #
=$$$ %
table$$& +
.$$+ ,
Column$$, 2
<$$2 3
Guid$$3 7
>$$7 8
($$8 9
type$$9 =
:$$= >
$str$$? Q
,$$Q R
nullable$$S [
:$$[ \
false$$] b
)$$b c
,$$c d
Status%% 
=%% 
table%% "
.%%" #
Column%%# )
<%%) *
int%%* -
>%%- .
(%%. /
type%%/ 3
:%%3 4
$str%%5 :
,%%: ;
nullable%%< D
:%%D E
false%%F K
)%%K L
,%%L M
	CreatedAt&& 
=&& 
table&&  %
.&&% &
Column&&& ,
<&&, -
DateTime&&- 5
>&&5 6
(&&6 7
type&&7 ;
:&&; <
$str&&= H
,&&H I
nullable&&J R
:&&R S
false&&T Y
)&&Y Z
,&&Z [
CompletedAt'' 
=''  !
table''" '
.''' (
Column''( .
<''. /
DateTime''/ 7
>''7 8
(''8 9
type''9 =
:''= >
$str''? J
,''J K
nullable''L T
:''T U
true''V Z
)''Z [
}(( 
,(( 
constraints)) 
:)) 
table)) "
=>))# %
{** 
table++ 
.++ 

PrimaryKey++ $
(++$ %
$str++% 2
,++2 3
x++4 5
=>++6 8
x++9 :
.++: ;
	PaymentId++; D
)++D E
;++E F
table,, 
.,, 

ForeignKey,, $
(,,$ %
name-- 
:-- 
$str-- I
,--I J
column.. 
:.. 
x..  !
=>.." $
x..% &
...& '
PaymentMethodId..' 6
,..6 7
principalTable// &
://& '
$str//( 7
,//7 8
principalColumn00 '
:00' (
$str00) :
,00: ;
onDelete11  
:11  !
ReferentialAction11" 3
.113 4
Cascade114 ;
)11; <
;11< =
}22 
)22 
;22 
migrationBuilder44 
.44 
CreateTable44 (
(44( )
name55 
:55 
$str55 
,55  
columns66 
:66 
table66 
=>66 !
new66" %
{77 
	InvoiceId88 
=88 
table88  %
.88% &
Column88& ,
<88, -
Guid88- 1
>881 2
(882 3
type883 7
:887 8
$str889 K
,88K L
nullable88M U
:88U V
false88W \
)88\ ]
,88] ^
	PaymentId99 
=99 
table99  %
.99% &
Column99& ,
<99, -
Guid99- 1
>991 2
(992 3
type993 7
:997 8
$str999 K
,99K L
nullable99M U
:99U V
false99W \
)99\ ]
,99] ^
IssuedAt:: 
=:: 
table:: $
.::$ %
Column::% +
<::+ ,
DateTime::, 4
>::4 5
(::5 6
type::6 :
:::: ;
$str::< G
,::G H
nullable::I Q
:::Q R
false::S X
)::X Y
,::Y Z
Number;; 
=;; 
table;; "
.;;" #
Column;;# )
<;;) *
string;;* 0
>;;0 1
(;;1 2
type;;2 6
:;;6 7
$str;;8 G
,;;G H
nullable;;I Q
:;;Q R
false;;S X
);;X Y
,;;Y Z
Status<< 
=<< 
table<< "
.<<" #
Column<<# )
<<<) *
int<<* -
><<- .
(<<. /
type<</ 3
:<<3 4
$str<<5 :
,<<: ;
nullable<<< D
:<<D E
false<<F K
)<<K L
}== 
,== 
constraints>> 
:>> 
table>> "
=>>># %
{?? 
table@@ 
.@@ 

PrimaryKey@@ $
(@@$ %
$str@@% 1
,@@1 2
x@@3 4
=>@@5 7
x@@8 9
.@@9 :
	InvoiceId@@: C
)@@C D
;@@D E
tableAA 
.AA 

ForeignKeyAA $
(AA$ %
nameBB 
:BB 
$strBB =
,BB= >
columnCC 
:CC 
xCC  !
=>CC" $
xCC% &
.CC& '
	PaymentIdCC' 0
,CC0 1
principalTableDD &
:DD& '
$strDD( 2
,DD2 3
principalColumnEE '
:EE' (
$strEE) 4
,EE4 5
onDeleteFF  
:FF  !
ReferentialActionFF" 3
.FF3 4
CascadeFF4 ;
)FF; <
;FF< =
}GG 
)GG 
;GG 
migrationBuilderII 
.II 
CreateIndexII (
(II( )
nameJJ 
:JJ 
$strJJ ,
,JJ, -
tableKK 
:KK 
$strKK  
,KK  !
columnLL 
:LL 
$strLL #
,LL# $
uniqueMM 
:MM 
trueMM 
)MM 
;MM 
migrationBuilderOO 
.OO 
CreateIndexOO (
(OO( )
namePP 
:PP 
$strPP 3
,PP3 4
tableQQ 
:QQ 
$strQQ !
,QQ! "
columnRR 
:RR 
$strRR )
)RR) *
;RR* +
}SS 	
	protectedVV 
overrideVV 
voidVV 
DownVV  $
(VV$ %
MigrationBuilderVV% 5
migrationBuilderVV6 F
)VVF G
{WW 	
migrationBuilderXX 
.XX 
	DropTableXX &
(XX& '
nameYY 
:YY 
$strYY 
)YY  
;YY  !
migrationBuilder[[ 
.[[ 
	DropTable[[ &
([[& '
name\\ 
:\\ 
$str\\  
)\\  !
;\\! "
migrationBuilder^^ 
.^^ 
	DropTable^^ &
(^^& '
name__ 
:__ 
$str__ %
)__% &
;__& '
}`` 	
}aa 
}bb –
yC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Infrastructure\Data\Context\SellGoldPaymentsContext.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Infrastructure *
.* +
Data+ /
./ 0
Context0 7
{ 
public 

class #
SellGoldPaymentsContext (
:) *
	DbContext+ 4
{ 
public #
SellGoldPaymentsContext &
(& '
DbContextOptions' 7
<7 8#
SellGoldPaymentsContext8 O
>O P
optionsQ X
)X Y
:Z [
base\ `
(` a
optionsa h
)h i
{		 	
}

 	
public 
DbSet 
< 
Payment 
> 
Payments &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
DbSet 
< 
PaymentMethod "
>" #
PaymentMethod$ 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
DbSet 
< 
Invoice 
> 
Invoice %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
modelBuilder 
. 
Entity 
<  
Payment  '
>' (
(( )
)) *
. 
OwnsOne 
( 
p 
=> 
p 
. 
PaymentMoney (
)( )
;) *
modelBuilder 
. 
Entity 
<  
Invoice  '
>' (
(( )
)) *
. 
OwnsOne 
( 
p 
=> 
p 
. 
InvoiceMoney (
)( )
;) *
} 	
} 
} †
_C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\ValueObjects\Money.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
ValueObjects# /
{ 
[ 
Owned 

]
 
public 

class 
Money 
{ 
public 
decimal 
Amount 
{ 
get  #
;# $
}% &
public		 
string		 
Currency		 
{		  
get		! $
;		$ %
}		& '
private 
Money 
( 
) 
{ 
Currency 
= 
string 
. 
Empty #
;# $
} 	
public 
Money 
( 
decimal 
value "
," #
string$ *
currency+ 3
)3 4
{ 	
if 
( 
value 
< 
$num 
) 
throw  
new! $
ArgumentException% 6
(6 7
$str7 U
)U V
;V W
Amount 
= 
value 
; 
Currency 
= 
currency 
??  "
throw# (
new) ,!
ArgumentNullException- B
(B C
nameofC I
(I J
currencyJ R
)R S
)S T
;T U
} 	
public 
Money 
Add 
( 
Money 
other $
)$ %
{ 	
EnsureSameCurrency 
( 
other $
)$ %
;% &
return 
new 
Money 
( 
Amount #
+$ %
other& +
.+ ,
Amount, 2
,2 3
Currency4 <
)< =
;= >
} 	
public 
Money 
Subtract 
( 
Money #
other$ )
)) *
{ 	
EnsureSameCurrency   
(   
other   $
)  $ %
;  % &
return!! 
new!! 
Money!! 
(!! 
Amount!! #
-!!$ %
other!!& +
.!!+ ,
Amount!!, 2
,!!2 3
Currency!!4 <
)!!< =
;!!= >
}"" 	
private$$ 
void$$ 
EnsureSameCurrency$$ '
($$' (
Money$$( -
other$$. 3
)$$3 4
{%% 	
if&& 
(&& 
Currency&& 
!=&& 
other&& !
.&&! "
Currency&&" *
)&&* +
throw'' 
new'' %
InvalidOperationException'' 3
(''3 4
$str''4 a
)''a b
;''b c
}(( 	
public** 
override** 
string** 
ToString** '
(**' (
)**( )
=>*** ,
$"**- /
{**/ 0
Currency**0 8
}**8 9
$str**9 :
{**: ;
Amount**; A
:**A B
$str**B D
}**D E
"**E F
;**F G
},, 
}-- ô
`C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\Enums\PaymentStatus.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
Enums# (
{ 
public 

enum 
PaymentStatus 
{ 
Pending 
, 

Authorized 
, 
Captured 
, 
Refunded 
, 
Failed		 
}

 
} ˙
dC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\Enums\PaymentMethodType.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
Enums# (
{ 
public 

enum 
PaymentMethodType !
{ 

CreditCard 
, 
	DebitCard 
, 
BankSlip 
, 
InstantPayment 
, 
DigitalWallet		 
,		 
BankTransfer

 
,

 
Cash 
} 
}  
`C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\Enums\InvoiceStatus.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
Enums# (
{ 
public 

enum 
InvoiceStatus 
{ 
Issued 
, 
Paid 
, 
Canceled 
} 
}		 Ó
cC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\Entities\PaymentMethod.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
Entities# +
{ 
public 

class 
PaymentMethod 
{ 
public 
Guid 
PaymentMethodId #
{$ %
get& )
;) *
private+ 2
set3 6
;6 7
}8 9
public 
string 
PaymentMethodCode '
{( )
get* -
;- .
private/ 6
set7 :
;: ;
}< =
public		 
PaymentMethodType		  
PaymentMethodType		! 2
{		3 4
get		5 8
;		8 9
private		: A
set		B E
;		E F
}		G H
public

 
bool

 !
SupportsAuthorization

 )
{

* +
get

, /
;

/ 0
private

1 8
set

9 <
;

< =
}

> ?
public 
bool 
SupportsCapture #
{$ %
get& )
;) *
private+ 2
set3 6
;6 7
}8 9
public 
bool !
SupportsPartialRefund )
{* +
get, /
;/ 0
private1 8
set9 <
;< =
}> ?
public 
bool 
IsActive 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
PaymentMethod 
( 
) 
{  
PaymentMethodCode 
= 
string  &
.& '
Empty' ,
;, -
} 	
public 
PaymentMethod 
( 
string 
paymentMethodCode $
,$ %
PaymentMethodType 
paymentMethodType /
,/ 0
bool !
supportsAuthorization &
,& '
bool 
supportsCapture  
,  !
bool !
supportsPartialRefund &
)& '
{ 	
PaymentMethodId 
= 
Guid "
." #
NewGuid# *
(* +
)+ ,
;, -
PaymentMethodCode 
= 
paymentMethodCode  1
??2 4
throw5 :
new; >!
ArgumentNullException? T
(T U
nameofU [
([ \
paymentMethodCode\ m
)m n
)n o
;o p
PaymentMethodType 
= 
paymentMethodType  1
;1 2!
SupportsAuthorization !
=" #!
supportsAuthorization$ 9
;9 :
SupportsCapture   
=   
supportsCapture   -
;  - .!
SupportsPartialRefund!! !
=!!" #!
supportsPartialRefund!!$ 9
;!!9 :
IsActive"" 
="" 
true"" 
;"" 
}## 	
public%% 
void%% 
Activate%% 
(%% 
)%% 
=>%% !
IsActive%%" *
=%%+ ,
true%%- 1
;%%1 2
public&& 
void&& 

Deactivate&& 
(&& 
)&&  
=>&&! #
IsActive&&$ ,
=&&- .
false&&/ 4
;&&4 5
}(( 
})) ó3
]C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\Entities\Payment.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
Entities# +
{ 
public 

class 
Payment 
{ 
public		 
Guid		 
	PaymentId		 
{		 
get		  #
;		# $
private		% ,
set		- 0
;		0 1
}		2 3
public

 
Money

 
PaymentMoney

 !
{

" #
get

$ '
;

' (
private

) 0
set

1 4
;

4 5
}

6 7
public 
PaymentMethod 
PaymentMethod *
{+ ,
get- 0
;0 1
private2 9
set: =
;= >
}? @
public 
PaymentStatus 
Status #
{$ %
get& )
;) *
private+ 2
set3 6
;6 7
}8 9
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
private) 0
set1 4
;4 5
}6 7
public 
DateTime 
? 
CompletedAt $
{% &
get' *
;* +
private, 3
set4 7
;7 8
}9 :
public 
Invoice 
Invoice 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
private 
Payment 
( 
) 
{ 
PaymentMoney 
= 
new 
Money $
($ %
$num% &
,& '
$str( *
)* +
;+ ,
PaymentMethod 
= 
new 
(  
)  !
;! "
Invoice 
= 
new 
( 
) 
; 
} 	
public 
Payment 
( 
Money 
paymentMoney )
,) *
PaymentMethod+ 8
paymentMethod9 F
,F G
InvoiceH O
invoiceP W
)W X
{ 	
	PaymentId 
= 
Guid 
. 
NewGuid $
($ %
)% &
;& '
PaymentMoney 
= 
paymentMoney '
??( *
throw+ 0
new1 4!
ArgumentNullException5 J
(J K
nameofK Q
(Q R
paymentMoneyR ^
)^ _
)_ `
;` a
PaymentMethod 
= 
paymentMethod )
??* ,
throw- 2
new3 6!
ArgumentNullException7 L
(L M
nameofM S
(S T
paymentMethodT a
)a b
)b c
;c d
Invoice 
= 
invoice 
??  
throw! &
new' *!
ArgumentNullException+ @
(@ A
nameofA G
(G H
invoiceH O
)O P
)P Q
;Q R
Status 
= 
PaymentStatus "
." #
Pending# *
;* +
	CreatedAt   
=   
DateTime    
.    !
UtcNow  ! '
;  ' (
}!! 	
public## 
void## 
	Authorize## 
(## 
)## 
{$$ 	
if%% 
(%% 
!%% 
PaymentMethod%% 
.%% !
SupportsAuthorization%% 4
)%%4 5
throw&& 
new&& %
InvalidOperationException&& 3
(&&3 4
$str&&4 U
)&&U V
;&&V W
Status'' 
='' 
PaymentStatus'' "
.''" #

Authorized''# -
;''- .
}(( 	
public** 
void** 
Capture** 
(** 
)** 
{++ 	
if,, 
(,, 
!,, 
PaymentMethod,, 
.,, 
SupportsCapture,, .
),,. /
throw-- 
new-- %
InvalidOperationException-- 3
(--3 4
$str--4 Q
)--Q R
;--R S
Status.. 
=.. 
PaymentStatus.. "
..." #
Captured..# +
;..+ ,
CompletedAt// 
=// 
DateTime// "
.//" #
UtcNow//# )
;//) *
}00 	
public22 
void22 
Refund22 
(22 
Money22  
refundAmount22! -
)22- .
{33 	
if44 
(44 
refundAmount44 
==44 
null44  $
)44$ %
throw44& +
new44, /!
ArgumentNullException440 E
(44E F
nameof44F L
(44L M
refundAmount44M Y
)44Y Z
)44Z [
;44[ \
if55 
(55 
refundAmount55 
.55 
Currency55 %
!=55& (
PaymentMoney55) 5
.555 6
Currency556 >
)55> ?
throw66 
new66 %
InvalidOperationException66 3
(663 4
$str664 g
)66g h
;66h i
bool99 
	isPartial99 
=99 
refundAmount99 )
.99) *
Amount99* 0
<991 2
PaymentMoney993 ?
.99? @
Amount99@ F
;99F G
if;; 
(;; 
	isPartial;; 
&&;; 
!;; 
PaymentMethod;; +
.;;+ ,!
SupportsPartialRefund;;, A
);;A B
throw<< 
new<< %
InvalidOperationException<< 3
(<<3 4
$str<<4 [
)<<[ \
;<<\ ]
if>> 
(>> 
refundAmount>> 
.>> 
Amount>> #
>>>$ %
PaymentMoney>>& 2
.>>2 3
Amount>>3 9
)>>9 :
throw?? 
new?? %
InvalidOperationException?? 3
(??3 4
$str??4 f
)??f g
;??g h
StatusAA 
=AA 
PaymentStatusAA "
.AA" #
RefundedAA# +
;AA+ ,
CompletedAtBB 
=BB 
DateTimeBB "
.BB" #
UtcNowBB# )
;BB) *
}CC 	
}EE 
}FF ®
]C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Domain\Entities\Invoice.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Domain "
." #
Entities# +
{ 
public 

class 
Invoice 
{ 
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public		 
Guid		 
	PaymentId		 
{		 
get		  #
;		# $
private		% ,
set		- 0
;		0 1
}		2 3
public

 
Money

 
InvoiceMoney

 !
{

" #
get

$ '
;

' (
private

) 0
set

1 4
;

4 5
}

6 7
public 
DateTime 
IssuedAt  
{! "
get# &
;& '
private( /
set0 3
;3 4
}5 6
public 
string 
Number 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
InvoiceStatus 
Status #
{$ %
get& )
;) *
private+ 2
set3 6
;6 7
}8 9
public 
Invoice 
( 
) 
{ 
InvoiceMoney 
= 
new 
Money $
($ %
$num% &
,& '
$str( *
)* +
;+ ,
Number 
= 
string 
. 
Empty !
;! "
} 	
public 
Invoice 
( 
Guid 
	paymentId %
,% &
Money' ,
invoiceMoney- 9
,9 :
string; A
numberB H
)H I
{ 	
	InvoiceId 
= 
Guid 
. 
NewGuid $
($ %
)% &
;& '
	PaymentId 
= 
	paymentId !
;! "
InvoiceMoney 
= 
invoiceMoney '
??( *
throw+ 0
new1 4!
ArgumentNullException5 J
(J K
nameofK Q
(Q R
invoiceMoneyR ^
)^ _
)_ `
;` a
Number 
= 
number 
?? 
throw $
new% (!
ArgumentNullException) >
(> ?
nameof? E
(E F
numberF L
)L M
)M N
;N O
IssuedAt 
= 
DateTime 
.  
UtcNow  &
;& '
Status 
= 
InvoiceStatus "
." #
Issued# )
;) *
} 	
public   
void   

MarkAsPaid   
(   
)    
{!! 	
Status"" 
="" 
InvoiceStatus"" "
.""" #
Paid""# '
;""' (
}## 	
public%% 
void%% 
Cancel%% 
(%% 
)%% 
{&& 	
Status'' 
='' 
InvoiceStatus'' "
.''" #
Canceled''# +
;''+ ,
}(( 	
}** 
}++ ƒ	
}C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Interfaces\Repositories\IPaymentsRepository.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (

Interfaces( 2
.2 3
Repositories3 ?
{ 
public 

	interface 
IPaymentsRepository (
{ 
Task 
< 
Payment 
> 
GetByIdAsync "
(" #
Guid# '
	paymentId( 1
)1 2
;2 3
Task 
< 
IEnumerable 
< 
Payment  
>  !
>! "
GetAllAsync# .
(. /
)/ 0
;0 1
Task		 
AddAsync		 
(		 
Payment		 
payment		 %
)		% &
;		& '
Task

 
UpdateAsync

 
(

 
Payment

  
payment

! (
)

( )
;

) *
Task 
DeleteAsync 
( 
Guid 
	paymentId '
)' (
;( )
} 
} ⁄
xC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Handlers\Payments\CreatePaymentHandler.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
Handlers( 0
.0 1
Payments1 9
{		 
public

 

class

  
CreatePaymentHandler

 %
:

& '
IRequestHandler

( 7
<

7 8 
CreatePaymentCommand

8 L
,

L M
PaymentResponse

N ]
>

] ^
{ 
private 
readonly 
IPaymentsRepository ,
_paymentsRepository- @
;@ A
private 
readonly 
IMapper  
_mapper! (
;( )
public  
CreatePaymentHandler #
(# $
IPaymentsRepository$ 7
paymentsRepository8 J
,J K
IMapperL S
mapperT Z
)Z [
{ 	
_paymentsRepository 
=  !
paymentsRepository" 4
;4 5
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
PaymentResponse )
>) *
Handle+ 1
(1 2 
CreatePaymentCommand2 F
commandG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 	
var 
payment 
= 
_mapper !
.! "
Map" %
<% &
Payment& -
>- .
(. /
command/ 6
.6 7 
createPaymentRequest7 K
)K L
;L M
await 
_paymentsRepository %
.% &
AddAsync& .
(. /
payment/ 6
)6 7
;7 8
var 
response 
= 
_mapper "
." #
Map# &
<& '
PaymentResponse' 6
>6 7
(7 8
payment8 ?
)? @
;@ A
return 
response 
; 
} 	
} 
} É=
xC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Contracts\Mappers\PaymentProfileMapper.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
	Contracts( 1
.1 2
Mappers2 9
{ 
public 

class  
PaymentProfileMapper %
:& '
Profile( /
{		 
public

  
PaymentProfileMapper

 #
(

# $
)

$ %
{ 	
	CreateMap 
<  
CreatePaymentRequest *
,* +
Payment, 3
>3 4
(4 5
)5 6
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
	PaymentId( 1
,1 2
opt3 6
=>7 9
opt: =
.= >
Ignore> D
(D E
)E F
)F G
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
PaymentMoney( 4
,4 5
opt6 9
=>: <
opt= @
.@ A
IgnoreA G
(G H
)H I
)I J
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
PaymentMethod( 5
,5 6
opt7 :
=>; =
opt> A
.A B
IgnoreB H
(H I
)I J
)J K
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Invoice( /
,/ 0
opt1 4
=>5 7
opt8 ;
.; <
Ignore< B
(B C
)C D
)D E
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Status( .
,. /
opt0 3
=>4 6
opt7 :
.: ;
Ignore; A
(A B
)B C
)C D
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
	CreatedAt( 1
,1 2
opt3 6
=>7 9
opt: =
.= >
Ignore> D
(D E
)E F
)F G
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
CompletedAt( 3
,3 4
opt5 8
=>9 ;
opt< ?
.? @
Ignore@ F
(F G
)G H
)H I
;I J
	CreateMap 
< 
Payment 
, 
PaymentResponse .
>. /
(/ 0
)0 1
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Amount( .
,. /
opt0 3
=>4 6
opt7 :
.: ;
MapFrom; B
(B C
srcC F
=>G I
srcJ M
.M N
PaymentMoneyN Z
.Z [
Amount[ a
)a b
)b c
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Currency( 0
,0 1
opt2 5
=>6 8
opt9 <
.< =
MapFrom= D
(D E
srcE H
=>I K
srcL O
.O P
PaymentMoneyP \
.\ ]
Currency] e
)e f
)f g
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
PaymentMethodId( 7
,7 8
opt9 <
=>= ?
opt@ C
.C D
MapFromD K
(K L
srcL O
=>P R
srcS V
.V W
PaymentMethodW d
.d e
PaymentMethodIde t
)t u
)u v
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
PaymentMethodCode( 9
,9 :
opt; >
=>? A
optB E
.E F
MapFromF M
(M N
srcN Q
=>R T
srcU X
.X Y
PaymentMethodY f
.f g
PaymentMethodCodeg x
)x y
)y z
.   
	ForMember   
(   
dest   
=>    "
dest  # '
.  ' (
PaymentMethodType  ( 9
,  9 :
opt  ; >
=>  ? A
opt  B E
.  E F
MapFrom  F M
(  M N
src  N Q
=>  R T
src  U X
.  X Y
PaymentMethod  Y f
.  f g
PaymentMethodType  g x
.  x y
ToString	  y Å
(
  Å Ç
)
  Ç É
)
  É Ñ
)
  Ñ Ö
.!! 
	ForMember!! 
(!! 
dest!! 
=>!!  "
dest!!# '
.!!' (
Status!!( .
,!!. /
opt!!0 3
=>!!4 6
opt!!7 :
.!!: ;
MapFrom!!; B
(!!B C
src!!C F
=>!!G I
src!!J M
.!!M N
Status!!N T
.!!T U
ToString!!U ]
(!!] ^
)!!^ _
)!!_ `
)!!` a
."" 
	ForMember"" 
("" 
dest"" 
=>""  "
dest""# '
.""' (
	InvoiceId""( 1
,""1 2
opt""3 6
=>""7 9
opt"": =
.""= >
MapFrom""> E
(""E F
src""F I
=>""J L
src""M P
.""P Q
Invoice""Q X
.""X Y
	InvoiceId""Y b
)""b c
)""c d
.## 
	ForMember## 
(## 
dest## 
=>##  "
dest### '
.##' (
InvoiceNumber##( 5
,##5 6
opt##7 :
=>##; =
opt##> A
.##A B
MapFrom##B I
(##I J
src##J M
=>##N P
src##Q T
.##T U
Invoice##U \
.##\ ]
Number##] c
)##c d
)##d e
.$$ 
	ForMember$$ 
($$ 
dest$$ 
=>$$  "
dest$$# '
.$$' (
InvoiceAmount$$( 5
,$$5 6
opt$$7 :
=>$$; =
opt$$> A
.$$A B
MapFrom$$B I
($$I J
src$$J M
=>$$N P
src$$Q T
.$$T U
Invoice$$U \
.$$\ ]
InvoiceMoney$$] i
.$$i j
Amount$$j p
)$$p q
)$$q r
.%% 
	ForMember%% 
(%% 
dest%% 
=>%%  "
dest%%# '
.%%' (
InvoiceCurrency%%( 7
,%%7 8
opt%%9 <
=>%%= ?
opt%%@ C
.%%C D
MapFrom%%D K
(%%K L
src%%L O
=>%%P R
src%%S V
.%%V W
Invoice%%W ^
.%%^ _
InvoiceMoney%%_ k
.%%k l
Currency%%l t
)%%t u
)%%u v
.&& 
	ForMember&& 
(&& 
dest&& 
=>&&  "
dest&&# '
.&&' (
InvoiceStatus&&( 5
,&&5 6
opt&&7 :
=>&&; =
opt&&> A
.&&A B
MapFrom&&B I
(&&I J
src&&J M
=>&&N P
src&&Q T
.&&T U
Invoice&&U \
.&&\ ]
Status&&] c
.&&c d
ToString&&d l
(&&l m
)&&m n
)&&n o
)&&o p
;&&p q
}'' 	
}(( 
})) Ÿ%
zC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Contracts\DTOs\Responses\PaymentResponse.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
	Contracts( 1
.1 2
DTOs2 6
.6 7
	Responses7 @
{ 
public 

class 
PaymentResponse  
{ 
[ 	
JsonPropertyName	 
( 
$str %
)% &
]& '
public 
Guid 
	PaymentId 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
decimal 
Amount 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
JsonPropertyName	 
( 
$str $
)$ %
]% &
public 
string 
Currency 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
[ 	
JsonPropertyName	 
( 
$str +
)+ ,
], -
public 
Guid 
PaymentMethodId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
JsonPropertyName	 
( 
$str -
)- .
]. /
public 
string 
PaymentMethodCode '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
string8 >
.> ?
Empty? D
;D E
[ 	
JsonPropertyName	 
( 
$str -
)- .
]. /
public 
string 
PaymentMethodType '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
string8 >
.> ?
Empty? D
;D E
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
[!! 	
JsonPropertyName!!	 
(!! 
$str!! %
)!!% &
]!!& '
public"" 
DateTime"" 
	CreatedAt"" !
{""" #
get""$ '
;""' (
set"") ,
;"", -
}"". /
[$$ 	
JsonPropertyName$$	 
($$ 
$str$$ '
)$$' (
]$$( )
public%% 
DateTime%% 
?%% 
CompletedAt%% $
{%%% &
get%%' *
;%%* +
set%%, /
;%%/ 0
}%%1 2
[)) 	
JsonPropertyName))	 
()) 
$str)) %
)))% &
]))& '
public** 
Guid** 
	InvoiceId** 
{** 
get**  #
;**# $
set**% (
;**( )
}*** +
[,, 	
JsonPropertyName,,	 
(,, 
$str,, )
),,) *
],,* +
public-- 
string-- 
InvoiceNumber-- #
{--$ %
get--& )
;--) *
set--+ .
;--. /
}--0 1
=--2 3
string--4 :
.--: ;
Empty--; @
;--@ A
[// 	
JsonPropertyName//	 
(// 
$str// )
)//) *
]//* +
public00 
decimal00 
InvoiceAmount00 $
{00% &
get00' *
;00* +
set00, /
;00/ 0
}001 2
[22 	
JsonPropertyName22	 
(22 
$str22 +
)22+ ,
]22, -
public33 
string33 
InvoiceCurrency33 %
{33& '
get33( +
;33+ ,
set33- 0
;330 1
}332 3
=334 5
string336 <
.33< =
Empty33= B
;33B C
[55 	
JsonPropertyName55	 
(55 
$str55 )
)55) *
]55* +
public66 
string66 
InvoiceStatus66 #
{66$ %
get66& )
;66) *
set66+ .
;66. /
}660 1
=662 3
string664 :
.66: ;
Empty66; @
;66@ A
}88 
}99 ö
~C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Contracts\DTOs\Requests\CreatePaymentRequest.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
	Contracts( 1
.1 2
DTOs2 6
.6 7
Requests7 ?
{ 
public 

class  
CreatePaymentRequest %
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[		 	
Range			 
(		 
typeof		 
(		 
decimal		 
)		 
,		 
$str		  #
,		# $
$str		% D
,		D E
ErrorMessage		F R
=		S T
$str		U w
)		w x
]		x y
public

 
decimal

 
Amount

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage %
=& '
$str( R
)R S
]S T
public 
string 
Currency 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
[ 	
Required	 
( 
ErrorMessage 
=  
$str! F
)F G
]G H
public 
Guid 
PaymentMethodId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Required	 
( 
ErrorMessage 
=  
$str! C
)C D
]D E
public 
string 
InvoiceNumber #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
string4 :
.: ;
Empty; @
;@ A
[ 	
Required	 
( 
ErrorMessage 
=  
$str! B
)B C
]C D
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage %
=& '
$str( \
)\ ]
]] ^
public 
string 
InvoiceCurrency %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
string6 <
.< =
Empty= B
;B C
[ 	
Required	 
( 
ErrorMessage 
=  
$str! B
)B C
]C D
[ 	
Range	 
( 
typeof 
( 
decimal 
) 
, 
$str  #
,# $
$str% D
,D E
ErrorMessageF R
=S T
$str	U Å
)
Å Ç
]
Ç É
public 
decimal 
InvoiceAmount $
{% &
get' *
;* +
set, /
;/ 0
}1 2
}   
}!! ·
eC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Commons\PaymentLogs.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
Commons( /
{ 
internal 
static 
partial 
class !
PaymentLogs" -
{ 
[ 	
LoggerMessage	 
( 
EventId 
= 
$num 
, 
Level 
= 
LogLevel 
. 
Information $
,$ %
Message 
= 
$str 8
)		 
]		 
public

 
static

 
partial

 
void

 "
PaymentNotFound

# 2
(

2 3
ILogger 
logger 
, 
Guid 
	paymentId 
) 
; 
} 
} Û
kC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Commons\NotFoundException.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
Commons( /
{ 
public 

sealed 
class 
NotFoundException )
:* +
ExceptionBase, 9
{ 
public 
NotFoundException  
(  !
string! '
entity( .
,. /
object0 6
key7 :
): ;
: 	
base
 
( 
$" 
{ 
entity 
} 
$str -
{- .
key. 1
}1 2
$str2 G
"G H
)H I
{ 	
} 	
}		 
}

 ç
gC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Commons\ExceptionBase.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
Commons( /
{ 
public 

abstract 
class 
ExceptionBase '
:( )
	Exception* 3
{ 
	protected 
ExceptionBase 
(  
string  &
message' .
). /
: 	
base
 
( 
message 
) 
{ 	
} 	
	protected

 
ExceptionBase

 
(

  
string

  &
message

' .
,

. /
	Exception

0 9
?

9 :
innerException

; I
)

I J
: 
base 
( 
message 
, 
innerException *
)* +
{ 	
} 	
} 
} √
oC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\Application\Commands\CreatePaymentCommand.cs
	namespace 	
SellGold
 
. 
Payments 
. 
Application '
.' (
Commands( 0
{ 
public 

record  
CreatePaymentCommand &
(& ' 
CreatePaymentRequest' ; 
createPaymentRequest< P
)P Q
:R S
IRequestT \
<\ ]
PaymentResponse] l
>l m
;m n
} ó
hC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Payments\API\Controllers\PaymentsController.cs
	namespace 	
SellGold
 
. 
Payments 
. 
API 
.  
Controllers  +
{ 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
PaymentsController

 #
:

$ %
ControllerBase

& 4
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
PaymentsController !
(! "
	IMediator" +
mediator, 4
)4 5
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
PaymentResponse' 6
>6 7
>7 8
CreatePayment9 F
(F G
[G H
FromBodyH P
]P Q 
CreatePaymentCommandR f
commandg n
)n o
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
{ 
return 

BadRequest !
(! "

ModelState" ,
), -
;- .
} 
var 

paymentDto 
= 
await "
	_mediator# ,
., -
Send- 1
(1 2
command2 9
)9 :
;: ;
return 

StatusCode 
( 
$num !
,! "

paymentDto# -
)- .
;. /
} 	
} 
} 