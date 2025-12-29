œ
ÉC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\AccumulatePointsRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class #
AccumulatePointsRequest /
{ 
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue $
)$ %
]% &
public 
decimal 
PurchaseValue $
{% &
get' *
;* +
set, /
;/ 0
}1 2
}		 
}

 ”
ÖC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\AccumulateCashbackRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class %
AccumulateCashbackRequest 1
{ 
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue $
)$ %
]% &
public 
decimal 
PurchaseValue $
{% &
get' *
;* +
set, /
;/ 0
}1 2
}		 
}

 Ì
iC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Commons\PromotionLogs.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Commons* 1
{ 
internal 
static 
partial 
class !
PromotionLogs" /
{ 
[ 	
LoggerMessage	 
( 
EventId 
= 
$num 
, 
Level		 
=		 
LogLevel		 
.		 
Information		 $
,		$ %
Message

 
=

 
$str

 9
) 
] 
public 
static 
partial 
void "
PromotionNotFound# 4
(4 5
ILogger 
logger 
, 
Guid 
promotionId 
) 
; 
} 
} ˜
mC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Commons\NotFoundException.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Commons* 1
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
 ë
iC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Commons\ExceptionBase.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Commons* 1
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
} —
sC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Commands\CreatePromotionCommand.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Commands* 2
{ 
public 

record "
CreatePromotionCommand (
(( )"
CreatePromotionRequest) ?"
createPromotionRequest@ V
)V W
:X Y
IRequestZ b
<b c
PromotionResponsec t
>t u
;u v
}		 ∏
uC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Commands\ActivatePromotionCommand.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Commands* 2
{ 
public 

record $
ActivatePromotionCommand *
(* +
Guid+ /
PromotionId0 ;
); <
:= >
IRequest? G
<G H
PromotionResponseH Y
>Y Z
;Z [
} Ù*
OC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
. 
AddNewtonsoftJson 
( 
options 
=> !
{ 
options 
. 
SerializerSettings "
." #!
ReferenceLoopHandling# 8
=9 :

Newtonsoft; E
.E F
JsonF J
.J K!
ReferenceLoopHandlingK `
.` a
Ignorea g
;g h
} 
) 
; 
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
	AddScoped 
< !
IPromotionsRepository 0
,0 1(
SellGoldPromotionsRepository2 N
>N O
(O P
)P Q
;Q R
builder 
. 
Services 
. 
AddDbContext 
< %
SellGoldPromotionsContext 7
>7 8
(8 9
options9 @
=>A C
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C
$strC a
)a b
)b c
)c d
;d e
builder 
. 
Services 
. 
AddAutoMapper 
( 
cfg "
=># %
{   
cfg!! 
.!! 

AddProfile!! 
<!! "
PromotionProfileMapper!! )
>!!) *
(!!* +
)!!+ ,
;!!, -
}"" 
)"" 
;"" 
builder%% 
.%% 
Services%% 
.%% 

AddMediatR%% 
(%% 
typeof&& 

(&&
 "
CreatePromotionHandler&& !
)&&! "
.&&" #
Assembly&&# +
)'' 
;'' 
builder** 
.** 
Services** 
.++ 
AddGraphQLServer++ 
(++ 
)++ 
.,, 
AddQueryType,, 
<,, 
PromotionQueryType,, $
>,,$ %
(,,% &
),,& '
.-- 
AddFiltering-- 
(-- 
)-- 
... 

AddSorting.. 
(.. 
).. 
;.. 
builder11 
.11 
Services11 
.11 
AddCors11 
(11 
options11  
=>11! #
{22 
options33 
.33 
	AddPolicy33 
(33 
$str33  
,33  !
policy44 
=>44 
policy44 
.44 
AllowAnyOrigin44 '
(44' (
)44( )
.55 
AllowAnyMethod55 '
(55' (
)55( )
.66 
AllowAnyHeader66 '
(66' (
)66( )
)66) *
;66* +
}77 
)77 
;77 
builder:: 
.:: 
Services:: 
.:: 

AddOpenApi:: 
(:: 
):: 
;:: 
var<< 
app<< 
=<< 	
builder<<
 
.<< 
Build<< 
(<< 
)<< 
;<< 
app?? 
.?? 
UseCors?? 
(?? 
$str?? 
)?? 
;?? 
appBB 
.BB 

MapGraphQLBB 
(BB 
$strBB 
)BB 
;BB 
voidEE 
ConfigureSwaggerUIEE 
(EE 
SwaggerUIOptionsEE (
cEE) *
)EE* +
{FF 
cGG 
.GG 
SwaggerEndpointGG 
(GG 
$strGG 0
,GG0 1
$strGG2 M
)GGM N
;GGN O
cHH 
.HH 
RoutePrefixHH 
=HH 
$strHH 
;HH 
}II 
ifKK 
(KK 
appKK 
.KK 
EnvironmentKK 
.KK 
IsDevelopmentKK !
(KK! "
)KK" #
||KK$ &
appKK' *
.KK* +
EnvironmentKK+ 6
.KK6 7
	IsStagingKK7 @
(KK@ A
)KKA B
)KKB C
{LL 
appMM 
.MM 

UseSwaggerMM 
(MM 
)MM 
;MM 
appNN 
.NN 
UseSwaggerUINN 
(NN 
ConfigureSwaggerUINN '
)NN' (
;NN( )
}OO 
appQQ 
.QQ 
UseHttpsRedirectionQQ 
(QQ 
)QQ 
;QQ 
appRR 
.RR 
UseAuthorizationRR 
(RR 
)RR 
;RR 
appSS 
.SS 
MapControllersSS 
(SS 
)SS 
;SS 
awaitUU 
appUU 	
.UU	 

RunAsyncUU
 
(UU 
)UU 
;UU ·#
ÄC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Infrastructure\Repositories\SellGoldPromotionsRepository.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Infrastructure ,
., -
Repositories- 9
{ 
public		 

class		 (
SellGoldPromotionsRepository		 -
:		. /!
IPromotionsRepository		0 E
{

 
private 
readonly %
SellGoldPromotionsContext 2
_context3 ;
;; <
public (
SellGoldPromotionsRepository +
(+ ,%
SellGoldPromotionsContext, E
contextF M
)M N
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
< 
	Promotion #
># $
GetByIdAsync% 1
(1 2
Guid2 6
promotionId7 B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 	
return 
await 
_context !
.! "

Promotions" ,
. 
FirstOrDefaultAsync 0
(0 1
p1 2
=>3 5
p6 7
.7 8
PromotionId8 C
==D F
promotionIdG R
)R S
??T V
throwW \
new] `#
InfrastructureExceptiona x
(x y
$"y {
$str	{ Ñ
{
Ñ Ö
promotionId
Ö ê
}
ê ë
$str
ë °
"
° ¢
)
¢ £
;
£ §
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
	Promotion& /
>/ 0
>0 1
GetAllAsync2 =
(= >
CancellationToken> O
cancellationTokenP a
)a b
{ 	
return 
await 
_context !
.! "

Promotions" ,
., -
ToListAsync- 8
(8 9
)9 :
;: ;
} 	
public 
async 
Task 
AddAsync "
(" #
	Promotion# ,
	promotion- 6
,6 7
CancellationToken8 I
cancellationTokenJ [
)[ \
{ 	
await 
_context 
. 

Promotions %
.% &
AddAsync& .
(. /
	promotion/ 8
)8 9
;9 :
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
(% &
	Promotion& /
	promotion0 9
,9 :
CancellationToken; L
cancellationTokenM ^
)^ _
{ 	
_context   
.   
Entry   
(   
	promotion   $
)  $ %
.  % &
State  & +
=  , -
EntityState  . 9
.  9 :
Modified  : B
;  B C
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
Guid##& *
promotionId##+ 6
,##6 7
CancellationToken##8 I
cancellationToken##J [
)##[ \
{$$ 	
var%% 
	promotion%% 
=%% 
await%% !
_context%%" *
.%%* +

Promotions%%+ 5
.%%5 6
	FindAsync%%6 ?
(%%? @
promotionId%%@ K
)%%K L
;%%L M
if&& 
(&& 
	promotion&& 
!=&& 
null&& !
)&&! "
{'' 
_context(( 
.(( 

Promotions(( #
.((# $
Remove(($ *
(((* +
	promotion((+ 4
)((4 5
;((5 6
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
}-- ö
yC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Infrastructure\Exceptions\InfrastructureException.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Infrastructure ,
., -

Exceptions- 7
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
} ÆE
ÉC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Infrastructure\Data\Migrations\20251216151424_InitialCreate.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Infrastructure ,
., -
Data- 1
.1 2

Migrations2 <
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
$str '
,' (
columns 
: 
table 
=> !
new" %
{ 
CashbackAccountId %
=& '
table( -
.- .
Column. 4
<4 5
Guid5 9
>9 :
(: ;
type; ?
:? @
$strA S
,S T
nullableU ]
:] ^
false_ d
)d e
,e f

CustomerId 
=  
table! &
.& '
Column' -
<- .
Guid. 2
>2 3
(3 4
type4 8
:8 9
$str: L
,L M
nullableN V
:V W
falseX ]
)] ^
,^ _
Balance 
= 
table #
.# $
Column$ *
<* +
decimal+ 2
>2 3
(3 4
type4 8
:8 9
$str: I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \
	CreatedAt 
= 
table  %
.% &
Column& ,
<, -
DateTime- 5
>5 6
(6 7
type7 ;
:; <
$str= H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
	UpdatedAt 
= 
table  %
.% &
Column& ,
<, -
DateTime- 5
>5 6
(6 7
type7 ;
:; <
$str= H
,H I
nullableJ R
:R S
falseT Y
)Y Z
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 9
,9 :
x; <
=>= ?
x@ A
.A B
CashbackAccountIdB S
)S T
;T U
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str &
,& '
columns 
: 
table 
=> !
new" %
{   
LoyaltyAccountId!! $
=!!% &
table!!' ,
.!!, -
Column!!- 3
<!!3 4
Guid!!4 8
>!!8 9
(!!9 :
type!!: >
:!!> ?
$str!!@ R
,!!R S
nullable!!T \
:!!\ ]
false!!^ c
)!!c d
,!!d e

CustomerId"" 
=""  
table""! &
.""& '
Column""' -
<""- .
Guid"". 2
>""2 3
(""3 4
type""4 8
:""8 9
$str"": L
,""L M
nullable""N V
:""V W
false""X ]
)""] ^
,""^ _
Points## 
=## 
table## "
.##" #
Column### )
<##) *
int##* -
>##- .
(##. /
type##/ 3
:##3 4
$str##5 :
,##: ;
nullable##< D
:##D E
false##F K
)##K L
,##L M
	CreatedAt$$ 
=$$ 
table$$  %
.$$% &
Column$$& ,
<$$, -
DateTime$$- 5
>$$5 6
($$6 7
type$$7 ;
:$$; <
$str$$= H
,$$H I
nullable$$J R
:$$R S
false$$T Y
)$$Y Z
,$$Z [
	UpdatedAt%% 
=%% 
table%%  %
.%%% &
Column%%& ,
<%%, -
DateTime%%- 5
>%%5 6
(%%6 7
type%%7 ;
:%%; <
$str%%= H
,%%H I
nullable%%J R
:%%R S
false%%T Y
)%%Y Z
}&& 
,&& 
constraints'' 
:'' 
table'' "
=>''# %
{(( 
table)) 
.)) 

PrimaryKey)) $
())$ %
$str))% 8
,))8 9
x)): ;
=>))< >
x))? @
.))@ A
LoyaltyAccountId))A Q
)))Q R
;))R S
}** 
)** 
;** 
migrationBuilder,, 
.,, 
CreateTable,, (
(,,( )
name-- 
:-- 
$str-- "
,--" #
columns.. 
:.. 
table.. 
=>.. !
new.." %
{// 
PromotionId00 
=00  !
table00" '
.00' (
Column00( .
<00. /
Guid00/ 3
>003 4
(004 5
type005 9
:009 :
$str00; M
,00M N
nullable00O W
:00W X
false00Y ^
)00^ _
,00_ `
Name11 
=11 
table11  
.11  !
Column11! '
<11' (
string11( .
>11. /
(11/ 0
type110 4
:114 5
$str116 E
,11E F
nullable11G O
:11O P
false11Q V
)11V W
,11W X
	StartDate22 
=22 
table22  %
.22% &
Column22& ,
<22, -
DateTime22- 5
>225 6
(226 7
type227 ;
:22; <
$str22= H
,22H I
nullable22J R
:22R S
false22T Y
)22Y Z
,22Z [
EndDate33 
=33 
table33 #
.33# $
Column33$ *
<33* +
DateTime33+ 3
>333 4
(334 5
type335 9
:339 :
$str33; F
,33F G
nullable33H P
:33P Q
false33R W
)33W X
,33X Y
Description44 
=44  !
table44" '
.44' (
Column44( .
<44. /
string44/ 5
>445 6
(446 7
type447 ;
:44; <
$str44= L
,44L M
nullable44N V
:44V W
false44X ]
)44] ^
,44^ _
DiscountPercentage55 &
=55' (
table55) .
.55. /
Column55/ 5
<555 6
decimal556 =
>55= >
(55> ?
type55? C
:55C D
$str55E T
,55T U
nullable55V ^
:55^ _
false55` e
)55e f
,55f g
	CreatedAt66 
=66 
table66  %
.66% &
Column66& ,
<66, -
DateTime66- 5
>665 6
(666 7
type667 ;
:66; <
$str66= H
,66H I
nullable66J R
:66R S
false66T Y
)66Y Z
,66Z [
	UpdatedAt77 
=77 
table77  %
.77% &
Column77& ,
<77, -
DateTime77- 5
>775 6
(776 7
type777 ;
:77; <
$str77= H
,77H I
nullable77J R
:77R S
false77T Y
)77Y Z
}88 
,88 
constraints99 
:99 
table99 "
=>99# %
{:: 
table;; 
.;; 

PrimaryKey;; $
(;;$ %
$str;;% 4
,;;4 5
x;;6 7
=>;;8 :
x;;; <
.;;< =
PromotionId;;= H
);;H I
;;;I J
}<< 
)<< 
;<< 
}== 	
	protected@@ 
override@@ 
void@@ 
Down@@  $
(@@$ %
MigrationBuilder@@% 5
migrationBuilder@@6 F
)@@F G
{AA 	
migrationBuilderBB 
.BB 
	DropTableBB &
(BB& '
nameCC 
:CC 
$strCC '
)CC' (
;CC( )
migrationBuilderEE 
.EE 
	DropTableEE &
(EE& '
nameFF 
:FF 
$strFF &
)FF& '
;FF' (
migrationBuilderHH 
.HH 
	DropTableHH &
(HH& '
nameII 
:II 
$strII "
)II" #
;II# $
}JJ 	
}KK 
}LL ∫
}C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Infrastructure\Data\Context\SellGoldPromotionsContext.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Infrastructure ,
., -
Data- 1
.1 2
Context2 9
{ 
public 

class %
SellGoldPromotionsContext *
:+ ,
	DbContext- 6
{ 
public %
SellGoldPromotionsContext (
(( )
DbContextOptions) 9
<9 :%
SellGoldPromotionsContext: S
>S T
optionsU \
)\ ]
:^ _
base` d
(d e
optionse l
)l m
{ 	
}		 	
public

 
DbSet

 
<

 
	Promotion

 
>

 

Promotions

  *
{

+ ,
get

- 0
;

0 1
set

2 5
;

5 6
}

7 8
public 
DbSet 
< 
LoyaltyAccount #
># $
LoyaltyAccount% 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
public 
DbSet 
< 
CashbackAccount $
>$ %
CashbackAccount& 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
} 
} ≠
cC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Domain\Exceptions\HitObject.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Domain $
.$ %

Exceptions% /
{ 
public 

abstract 
class 
	HitObject #
{ 
	protected 
abstract 
IEnumerable &
<& '
object' -
?- .
>. /!
GetEqualityComponents0 E
(E F
)F G
;G H
public 
override 
bool 
Equals #
(# $
object$ *
?* +
obj, /
)/ 0
{ 	
if		 
(		 
obj		 
is		 
null		 
||		 
obj		 "
.		" #
GetType		# *
(		* +
)		+ ,
!=		- /
GetType		0 7
(		7 8
)		8 9
)		9 :
return

 
false

 
;

 
var 
other 
= 
( 
	HitObject "
)" #
obj# &
;& '
return !
GetEqualityComponents (
(( )
)) *
. 
SequenceEqual 
( 
other $
.$ %!
GetEqualityComponents% :
(: ;
); <
)< =
;= >
} 	
public 
override 
int 
GetHashCode '
(' (
)( )
{ 	
	unchecked 
{ 
int 
hash 
= 
$num 
; 
foreach 
( 
var 
	component &
in' )!
GetEqualityComponents* ?
(? @
)@ A
)A B
{ 
hash 
= 
hash 
*  !
$num" $
+% &
(' (
	component( 1
?1 2
.2 3
GetHashCode3 >
(> ?
)? @
??A C
$numD E
)E F
;F G
} 
return 
hash 
; 
} 
} 	
}   
}!! Í
iC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Domain\Exceptions\DomainException.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Domain $
.$ %

Exceptions% /
{ 
public 

class 
DomainException  
:! "
	Exception# ,
{ 
public 
DomainException 
( 
string %
message& -
)- .
: 
base 
( 
message 
) 
{ 	
} 	
public

 
DomainException

 
(

 
string

 %
message

& -
,

- .
	Exception

/ 8
innerException

9 G
)

G H
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
} µ;
aC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Domain\Entities\Promotion.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Domain $
.$ %
Entities% -
{ 
public 

sealed 
class 
	Promotion !
{ 
	protected 
	Promotion 
( 
) 
{ 
}  !
private

 
	Promotion

 
(

 
Guid 
promotionId 
, 
string 
name 
, 
DateTime 
	startDate 
, 
DateTime 
endDate 
, 
decimal 
discountPercentage &
,& '
string 
description 
, 
DateTime 
	createdAt 
, 
DateTime 
	updatedAt 
) 
{ 	
PromotionId 
= 
promotionId %
;% &
Name 
= 
name 
; 
	StartDate 
= 
	startDate !
;! "
EndDate 
= 
endDate 
; 
DiscountPercentage 
=  
discountPercentage! 3
;3 4
Description 
= 
description %
;% &
	CreatedAt 
= 
	createdAt !
;! "
	UpdatedAt 
= 
	updatedAt !
;! "
} 	
public!! 
static!! 
	Promotion!! 
Create!!  &
(!!& '
string"" 
name"" 
,"" 
DateTime## 
	startDate## 
,## 
DateTime$$ 
endDate$$ 
,$$ 
decimal%% 
discountPercentage%% &
,%%& '
string&& 
?&& 
description&& 
=&&  !
null&&" &
)&&& '
{'' 	
Validate(( 
((( 
name(( 
,(( 
	startDate(( $
,(($ %
endDate((& -
,((- .
discountPercentage((/ A
)((A B
;((B C
var** 
now** 
=** 
DateTime** 
.** 
UtcNow** %
;**% &
return,, 
new,, 
	Promotion,,  
(,,  !
Guid-- 
.-- 
NewGuid-- 
(-- 
)-- 
,-- 
name.. 
... 
Trim.. 
(.. 
).. 
,.. 
	startDate// 
,// 
endDate00 
,00 
discountPercentage11 "
,11" #
description22 
?22 
.22 
Trim22 !
(22! "
)22" #
??22$ &
string22' -
.22- .
Empty22. 3
,223 4
now33 
,33 
now44 
)55 
;55 
}66 	
public;; 
Guid;; 
PromotionId;; 
{;;  !
get;;" %
;;;% &
private;;' .
set;;/ 2
;;;2 3
};;4 5
public<< 
string<< 
Name<< 
{<< 
get<<  
;<<  !
private<<" )
set<<* -
;<<- .
}<</ 0
=<<1 2
string<<3 9
.<<9 :
Empty<<: ?
;<<? @
public== 
DateTime== 
	StartDate== !
{==" #
get==$ '
;==' (
private==) 0
set==1 4
;==4 5
}==6 7
public>> 
DateTime>> 
EndDate>> 
{>>  !
get>>" %
;>>% &
private>>' .
set>>/ 2
;>>2 3
}>>4 5
public?? 
decimal?? 
DiscountPercentage?? )
{??* +
get??, /
;??/ 0
private??1 8
set??9 <
;??< =
}??> ?
public@@ 
string@@ 
Description@@ !
{@@" #
get@@$ '
;@@' (
private@@) 0
set@@1 4
;@@4 5
}@@6 7
=@@8 9
string@@: @
.@@@ A
Empty@@A F
;@@F G
publicAA 
DateTimeAA 
	CreatedAtAA !
{AA" #
getAA$ '
;AA' (
privateAA) 0
setAA1 4
;AA4 5
}AA6 7
publicBB 
DateTimeBB 
	UpdatedAtBB !
{BB" #
getBB$ '
;BB' (
privateBB) 0
setBB1 4
;BB4 5
}BB6 7
publicGG 
voidGG 
UpdateGG 
(GG 
stringHH 
nameHH 
,HH 
DateTimeII 
	startDateII 
,II 
DateTimeJJ 
endDateJJ 
,JJ 
decimalKK 
discountPercentageKK &
,KK& '
stringLL 
?LL 
descriptionLL 
)LL  
{MM 	
ValidateNN 
(NN 
nameNN 
,NN 
	startDateNN $
,NN$ %
endDateNN& -
,NN- .
discountPercentageNN/ A
)NNA B
;NNB C
NamePP 
=PP 
namePP 
.PP 
TrimPP 
(PP 
)PP 
;PP 
	StartDateQQ 
=QQ 
	startDateQQ !
;QQ! "
EndDateRR 
=RR 
endDateRR 
;RR 
DiscountPercentageSS 
=SS  
discountPercentageSS! 3
;SS3 4
DescriptionTT 
=TT 
descriptionTT %
?TT% &
.TT& '
TrimTT' +
(TT+ ,
)TT, -
??TT. 0
stringTT1 7
.TT7 8
EmptyTT8 =
;TT= >
	UpdatedAtUU 
=UU 
DateTimeUU  
.UU  !
UtcNowUU! '
;UU' (
}VV 	
publicXX 
boolXX 
IsActiveXX 
(XX 
DateTimeXX %
referenceDateXX& 3
)XX3 4
=>YY 
referenceDateYY 
>=YY 
	StartDateYY  )
&&YY* ,
referenceDateYY- :
<=YY; =
EndDateYY> E
;YYE F
private^^ 
static^^ 
void^^ 
Validate^^ $
(^^$ %
string__ 
name__ 
,__ 
DateTime`` 
	startDate`` 
,`` 
DateTimeaa 
endDateaa 
,aa 
decimalbb 
discountPercentagebb &
)bb& '
{cc 	
ifdd 
(dd 
stringdd 
.dd 
IsNullOrWhiteSpacedd )
(dd) *
namedd* .
)dd. /
)dd/ 0
throwee 
newee 
DomainExceptionee )
(ee) *
$stree* M
)eeM N
;eeN O
ifgg 
(gg 
	startDategg 
>=gg 
endDategg $
)gg$ %
throwhh 
newhh 
DomainExceptionhh )
(hh) *
$strhh* [
)hh[ \
;hh\ ]
ifjj 
(jj 
discountPercentagejj "
<=jj# %
$numjj& '
||jj( *
discountPercentagejj+ =
>jj> ?
$numjj@ C
)jjC D
throwkk 
newkk 
DomainExceptionkk )
(kk) *
$strkk* ^
)kk^ _
;kk_ `
}ll 	
}mm 
}nn ⁄
fC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Domain\Entities\LoyaltyAccount.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Domain $
.$ %
Entities% -
{ 
public 

class 
LoyaltyAccount 
{ 
	protected 
LoyaltyAccount  
(  !
)! "
{# $
}% &
public

 
LoyaltyAccount

 
(

 
Guid

 "

customerId

# -
)

- .
{ 	
if 
( 

customerId 
== 
Guid "
." #
Empty# (
)( )
throw 
new 
DomainException )
() *
$str* =
)= >
;> ?
LoyaltyAccountId 
= 
Guid #
.# $
NewGuid$ +
(+ ,
), -
;- .

CustomerId 
= 

customerId #
;# $
Points 
= 
$num 
; 
	CreatedAt 
= 
DateTime  
.  !
UtcNow! '
;' (
	UpdatedAt 
= 
DateTime  
.  !
UtcNow! '
;' (
} 	
public 
Guid 
LoyaltyAccountId $
{% &
get' *
;* +
private, 3
set4 7
;7 8
}9 :
public 
Guid 

CustomerId 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
int 
Points 
{ 
get 
;  
private! (
set) ,
;, -
}. /
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
private) 0
set1 4
;4 5
}6 7
public 
DateTime 
	UpdatedAt !
{" #
get$ '
;' (
private) 0
set1 4
;4 5
}6 7
public 
void 
AccumulatePoints $
($ %
decimal% ,
purchaseValue- :
): ;
{ 	
if   
(   
purchaseValue   
<=    
$num  ! "
)  " #
throw!! 
new!! 
DomainException!! )
(!!) *
$str!!* T
)!!T U
;!!U V
var%% 
earnedPoints%% 
=%% 
(%%  
int%%  #
)%%# $
(%%$ %
purchaseValue%%% 2
/%%3 4
$num%%5 7
)%%7 8
;%%8 9
if'' 
('' 
earnedPoints'' 
<='' 
$num''  !
)''! "
return(( 
;(( 
Points** 
+=** 
earnedPoints** "
;**" #
	UpdatedAt++ 
=++ 
DateTime++  
.++  !
UtcNow++! '
;++' (
},, 	
public.. 
void.. 
RedeemPoints..  
(..  !
int..! $
points..% +
)..+ ,
{// 	
if00 
(00 
points00 
<=00 
$num00 
)00 
throw11 
new11 
DomainException11 )
(11) *
$str11* J
)11J K
;11K L
if33 
(33 
points33 
>33 
Points33 
)33  
throw44 
new44 
DomainException44 )
(44) *
$str44* I
)44I J
;44J K
Points66 
-=66 
points66 
;66 
	UpdatedAt77 
=77 
DateTime77  
.77  !
UtcNow77! '
;77' (
}88 	
}99 
}:: ™
gC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Domain\Entities\CashbackAccount.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Domain $
.$ %
Entities% -
{ 
public 

class 
CashbackAccount  
{ 
	protected 
CashbackAccount !
(! "
)" #
{$ %
}& '
public

 
CashbackAccount

 
(

 
Guid

 #

customerId

$ .
)

. /
{ 	
if 
( 

customerId 
== 
Guid "
." #
Empty# (
)( )
throw 
new 
DomainException )
() *
$str* =
)= >
;> ?
CashbackAccountId 
= 
Guid  $
.$ %
NewGuid% ,
(, -
)- .
;. /

CustomerId 
= 

customerId #
;# $
Balance 
= 
$num 
; 
	CreatedAt 
= 
DateTime  
.  !
UtcNow! '
;' (
	UpdatedAt 
= 
DateTime  
.  !
UtcNow! '
;' (
} 	
public 
Guid 
CashbackAccountId %
{& '
get( +
;+ ,
private- 4
set5 8
;8 9
}: ;
public 
Guid 

CustomerId 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
decimal 
Balance 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
private) 0
set1 4
;4 5
}6 7
public 
DateTime 
	UpdatedAt !
{" #
get$ '
;' (
private) 0
set1 4
;4 5
}6 7
public 
void 
AccumulateCashback &
(& '
decimal' .
purchaseValue/ <
)< =
{ 	
if   
(   
purchaseValue   
<=    
$num  ! "
)  " #
throw!! 
new!! 
DomainException!! )
(!!) *
$str!!* T
)!!T U
;!!U V
var%% 
cashbackAmount%% 
=%%  
purchaseValue%%! .
*%%/ 0
$num%%1 6
;%%6 7
if'' 
('' 
cashbackAmount'' 
<='' !
$num''" #
)''# $
return(( 
;(( 
Balance** 
+=** 
cashbackAmount** %
;**% &
	UpdatedAt++ 
=++ 
DateTime++  
.++  !
UtcNow++! '
;++' (
},, 	
public.. 
void.. 
RedeemCashback.. "
(.." #
decimal..# *
amount..+ 1
)..1 2
{// 	
if00 
(00 
amount00 
<=00 
$num00 
)00 
throw11 
new11 
DomainException11 )
(11) *
$str11* H
)11H I
;11I J
if33 
(33 
amount33 
>33 
Balance33  
)33  !
throw44 
new44 
DomainException44 )
(44) *
$str44* K
)44K L
;44L M
Balance66 
-=66 
amount66 
;66 
	UpdatedAt77 
=77 
DateTime77  
.77  !
UtcNow77! '
;77' (
}88 	
}99 
}:: Î
ÄC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Queries\GraphQL\GetPromotionByIdGraphQLQuery.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Queries* 1
.1 2
GraphQL2 9
{ 
public 

record (
GetPromotionByIdGraphQLQuery .
(. /
Guid/ 3
PromotionId4 ?
)? @
:A B
IRequestC K
<K L
PromotionResponseL ]
>] ^
;^ _
} Ï
C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Queries\GraphQL\GetAllPromotionGraphQLQuery.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Queries* 1
.1 2
GraphQL2 9
{ 
public 

class '
GetAllPromotionGraphQLQuery ,
(, -
)- .
:/ 0
IRequest1 9
<9 :
List: >
<> ?
PromotionResponse? P
>P Q
>Q R
;R S
} œ
ÅC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Interfaces\Repositories\IPromotionsRepository.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *

Interfaces* 4
.4 5
Repositories5 A
{ 
public 

	interface !
IPromotionsRepository *
{ 
Task 
< 
	Promotion 
> 
GetByIdAsync $
($ %
Guid% )
promotionId* 5
,5 6
CancellationToken7 H
cancellationTokenI Z
)Z [
;[ \
Task 
< 
IEnumerable 
< 
	Promotion "
>" #
># $
GetAllAsync% 0
(0 1
CancellationToken1 B
cancellationTokenC T
)T U
;U V
Task 
AddAsync 
( 
	Promotion 
	promotion  )
,) *
CancellationToken+ <
cancellationToken= N
)N O
;O P
Task		 
UpdateAsync		 
(		 
	Promotion		 "
	promotion		# ,
,		, -
CancellationToken		. ?
cancellationToken		@ Q
)		Q R
;		R S
Task

 
DeleteAsync

 
(

 
Guid

 
promotionId

 )
,

) *
CancellationToken

+ <
cancellationToken

= N
)

N O
;

O P
} 
} ∏
~C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Handlers\Promotions\CreatePromotionHandler.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Handlers* 2
.2 3

Promotions3 =
{		 
public

 

class

 "
CreatePromotionHandler

 '
:

( )
IRequestHandler

* 9
<

9 :"
CreatePromotionCommand

: P
,

P Q
PromotionResponse

R c
>

c d
{ 
private 
readonly !
IPromotionsRepository .!
_promotionsRepository/ D
;D E
private 
readonly 
IMapper  
_mapper! (
;( )
public "
CreatePromotionHandler %
(% &!
IPromotionsRepository& ; 
promotionsRepository< P
,P Q
IMapperR Y
mapperZ `
)` a
{ 	!
_promotionsRepository !
=" # 
promotionsRepository$ 8
;8 9
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
PromotionResponse +
>+ ,
Handle- 3
(3 4"
CreatePromotionCommand4 J
commandK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 	
var 
	promotion 
= 
_mapper #
.# $
Map$ '
<' (
	Promotion( 1
>1 2
(2 3
command3 :
.: ;"
createPromotionRequest; Q
)Q R
;R S
await !
_promotionsRepository '
.' (
AddAsync( 0
(0 1
	promotion1 :
,: ;
cancellationToken< M
)M N
;N O
var 
response 
= 
_mapper "
." #
Map# &
<& '
PromotionResponse' 8
>8 9
(9 :
	promotion: C
)C D
;D E
return 
response 
; 
} 	
}   
}!! ÿ
ÄC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Handlers\Promotions\ActivatePromotionHandler.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Handlers* 2
.2 3

Promotions3 =
{		 
public

 

class

 $
ActivatePromotionHandler

 )
:

* +
IRequestHandler

, ;
<

; <$
ActivatePromotionCommand

< T
,

T U
PromotionResponse

V g
>

g h
{ 
private 
readonly !
IPromotionsRepository .!
_promotionsRepository/ D
;D E
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ILogger  
<  !$
ActivatePromotionHandler! 9
>9 :
_logger; B
;B C
public $
ActivatePromotionHandler '
(' (!
IPromotionsRepository( = 
promotionsRepository> R
,R S
IMapper( /
mapper0 6
,6 7
ILogger( /
</ 0$
ActivatePromotionHandler0 H
>H I
loggerJ P
)P Q
{ 	!
_promotionsRepository !
=" # 
promotionsRepository$ 8
;8 9
_mapper 
= 
mapper 
; 
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
< 
PromotionResponse +
>+ ,
Handle- 3
(3 4$
ActivatePromotionCommand4 L
commandM T
,T U
CancellationTokenV g
cancellationTokenh y
)y z
{ 	
var 
	promotion 
= 
await !!
_promotionsRepository" 7
.7 8
GetByIdAsync8 D
(D E
commandE L
.L M
PromotionIdM X
,X Y
cancellationTokenZ k
)k l
;l m
if 
( 
	promotion 
== 
null !
)! "
{ 
PromotionLogs 
. 
PromotionNotFound /
(/ 0
_logger0 7
,7 8
command9 @
.@ A
PromotionIdA L
)L M
;M N
throw 
new 
NotFoundException +
(+ ,
$str, 8
,8 9
command: A
.A B
PromotionIdB M
)M N
;N O
} 
if   
(   
!   
	promotion   
.   
IsActive   "
(  " #
DateTime  # +
.  + ,
UtcNow  , 2
)  2 3
)  3 4
{!! 
	promotion"" 
."" 
IsActive"" "
(""" #
DateTime""# +
.""+ ,
UtcNow"", 2
)""2 3
;""3 4
}## 
return$$ 
_mapper$$ 
.$$ 
Map$$ 
<$$ 
PromotionResponse$$ 0
>$$0 1
($$1 2
	promotion$$2 ;
)$$; <
;$$< =
}%% 	
}&& 
}'' ¯
ÉC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Handlers\GraphQL\GetPromotionByIdGraphQLHandler.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Handlers* 2
.2 3
GraphQL3 :
{		 
public

 

class

 *
GetPromotionByIdGraphQLHandler

 /
:

0 1
IRequestHandler

2 A
<

A B(
GetPromotionByIdGraphQLQuery

B ^
,

^ _
PromotionResponse

` q
>

q r
{ 
private 
readonly !
IPromotionsRepository .!
_promotionsRepository/ D
;D E
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ILogger  
_logger! (
;( )
public *
GetPromotionByIdGraphQLHandler -
(- .!
IPromotionsRepository. C 
promotionsRepositoryD X
,X Y
IMapperZ a
mapperb h
,h i
ILoggerj q
<q r+
GetPromotionByIdGraphQLHandler	r ê
>
ê ë
logger
í ò
)
ò ô
{ 	!
_promotionsRepository !
=" # 
promotionsRepository$ 8
;8 9
_mapper 
= 
mapper 
; 
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
< 
PromotionResponse +
>+ ,
Handle- 3
(3 4(
GetPromotionByIdGraphQLQuery4 P
queryQ V
,V W
CancellationTokenX i
cancellationTokenj {
){ |
{ 	
var 
	promotion 
= 
await !!
_promotionsRepository" 7
.7 8
GetByIdAsync8 D
(D E
queryE J
.J K
PromotionIdK V
,V W
cancellationTokenX i
)i j
;j k
if 
( 
	promotion 
== 
null !
)! "
{ 
PromotionLogs 
. 
PromotionNotFound /
(/ 0
_logger0 7
,7 8
query9 >
.> ?
PromotionId? J
)J K
;K L
throw 
new 
NotFoundException +
(+ ,
$str, 8
,8 9
query: ?
.? @
PromotionId@ K
)K L
;M N
} 
var   
response   
=   
_mapper   "
.  " #
Map  # &
<  & '
PromotionResponse  ' 8
>  8 9
(  9 :
	promotion  : C
)  C D
;  D E
return"" 
response"" 
;"" 
}## 	
}%% 
}&& â
ÉC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Handlers\GraphQL\GetAllPromotionsGraphQLHandler.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
Handlers* 2
.2 3
GraphQL3 :
{ 
public		 

class		 *
GetAllPromotionsGraphQLHandler		 /
:		0 1
IRequestHandler		2 A
<		A B'
GetAllPromotionGraphQLQuery		B ]
,		] ^
List		_ c
<		c d
PromotionResponse		d u
>		u v
>		v w
{

 
private 
readonly !
IPromotionsRepository .!
_promotionsRepository/ D
;D E
private 
readonly 
IMapper  
_mapper! (
;( )
public *
GetAllPromotionsGraphQLHandler -
(- .!
IPromotionsRepository. C 
promotionsRepositoryD X
,X Y
IMapperZ a
mapperb h
)h i
{ 	!
_promotionsRepository !
=" # 
promotionsRepository$ 8
;8 9
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
List 
< 
PromotionResponse 0
>0 1
>1 2
Handle3 9
(9 :'
GetAllPromotionGraphQLQuery: U
queryV [
,[ \
CancellationToken] n
cancellationToken	o Ä
)
Ä Å
{ 	
var 
	promotion 
= 
await !!
_promotionsRepository" 7
.7 8
GetAllAsync8 C
(C D
cancellationTokenD U
)U V
;V W
return 
_mapper 
. 
Map 
< 
List #
<# $
PromotionResponse$ 5
>5 6
>6 7
(7 8
	promotion8 A
)A B
;B C
} 	
} 
} Ó#
|C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\Mappers\PromotionProfileMapper.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
Mappers4 ;
{ 
public 

class "
PromotionProfileMapper '
:( )
Profile* 1
{		 
public

 "
PromotionProfileMapper

 %
(

% &
)

& '
{ 	
	CreateMap 
< "
CreatePromotionRequest ,
,, -
	Promotion. 7
>7 8
(8 9
)9 :
. 
ConstructUsing 
(  
src  #
=>$ &
	Promotion 
. 
Create $
($ %
src 
. 
Name  
,  !
src 
. 
	StartDate %
,% &
src 
. 
EndDate #
,# $
src 
. 
DiscountPercentage .
,. /
src 
. 
Description '
) 
) 
; 
	CreateMap 
< 
	Promotion 
,  
PromotionResponse! 2
>2 3
(3 4
)4 5
. 
	ForMember 
( 
dest 
=> 
dest  
.  !
PromotionId! ,
,, -
opt 
=> 
opt 
. 
MapFrom &
(& '
src' *
=>+ -
src. 1
.1 2
PromotionId2 =
)= >
)> ?
. 
	ForMember 
( 
dest 
=> 
dest  
.  !
IsActive! )
,) *
opt 
=> 
opt 
. 
MapFrom &
(& '
src' *
=>+ -
src. 1
.1 2
IsActive2 :
(: ;
DateTime; C
.C D
UtcNowD J
)J K
)K L
)L M
. 
	ForMember 
( 
dest 
=> 
dest  
.  !
Name! %
,% &
opt   
=>   
opt   
.   
MapFrom   &
(  & '
src  ' *
=>  + -
src  . 1
.  1 2
Name  2 6
)  6 7
)  7 8
.!! 
	ForMember!! 
(!! 
dest"" 
=>"" 
dest""  
.""  !
Description""! ,
,"", -
opt## 
=>## 
opt## 
.## 
MapFrom## &
(##& '
src##' *
=>##+ -
src##. 1
.##1 2
Description##2 =
)##= >
)##> ?
.$$ 
	ForMember$$ 
($$ 
dest%% 
=>%% 
dest%%  
.%%  !
	StartDate%%! *
,%%* +
opt&& 
=>&& 
opt&& 
.&& 
MapFrom&& &
(&&& '
src&&' *
=>&&+ -
src&&. 1
.&&1 2
	StartDate&&2 ;
)&&; <
)&&< =
.'' 
	ForMember'' 
('' 
dest(( 
=>(( 
dest((  
.((  !
EndDate((! (
,((( )
opt)) 
=>)) 
opt)) 
.)) 
MapFrom)) &
())& '
src))' *
=>))+ -
src)). 1
.))1 2
EndDate))2 9
)))9 :
))): ;
.** 
	ForMember** 
(** 
dest++ 
=>++ 
dest++  
.++  !
DiscountPercentage++! 3
,++3 4
opt,, 
=>,, 
opt,, 
.,, 
MapFrom,, &
(,,& '
src,,' *
=>,,+ -
src,,. 1
.,,1 2
DiscountPercentage,,2 D
),,D E
),,E F
.-- 
	ForMember-- 
(-- 
dest.. 
=>.. 
dest..  
...  !
	CreatedAt..! *
,..* +
opt// 
=>// 
opt// 
.// 
MapFrom// &
(//& '
src//' *
=>//+ -
src//. 1
.//1 2
	CreatedAt//2 ;
)//; <
)//< =
;//= >
}00 	
}11 
}22 ≤
ÅC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\Mappers\LoyaltyAccountProfileMapper.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
Mappers4 ;
{ 
public 

sealed 
class '
LoyaltyAccountProfileMapper 3
:4 5
Profile6 =
{ 
public		 '
LoyaltyAccountProfileMapper		 *
(		* +
)		+ ,
{

 	
	CreateMap 
< 
LoyaltyAccount $
,$ %"
LoyaltyAccountResponse& <
>< =
(= >
)> ?
;? @
} 	
} 
} £
ÇC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\Mappers\CashbackAccountProfileMapper.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
Mappers4 ;
{ 
public 

class (
CashbackAccountProfileMapper -
:. /
Profile0 7
{ 
public		 (
CashbackAccountProfileMapper		 +
(		+ ,
)		, -
{

 	
	CreateMap 
< 
CashbackAccount %
,% &#
CashbackAccountResponse' >
>> ?
(? @
)@ A
;A B
} 	
} 
} ¥

ÜC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Responses\ValidatePromotionResponse.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
	Responses9 B
{ 
public 

sealed 
class %
ValidatePromotionResponse 1
{ 
public 
bool 
IsValid 
{ 
get !
;! "
init# '
;' (
}) *
public 
decimal 
DiscountAmount %
{& '
get( +
;+ ,
init- 1
;1 2
}3 4
public 
decimal 
CashbackAmount %
{& '
get( +
;+ ,
init- 1
;1 2
}3 4
public 
int 
EarnedPoints 
{  !
get" %
;% &
init' +
;+ ,
}- .
public		 
string		 
?		 
Reason		 
{		 
get		  #
;		# $
init		% )
;		) *
}		+ ,
}

 
} ú
~C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Responses\PromotionResponse.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
	Responses9 B
{ 
public 

class 
PromotionResponse "
{ 
public 
Guid 
PromotionId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 
DateTime 
	StartDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
EndDate 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
string		 
Description		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
=		0 1
string		2 8
.		8 9
Empty		9 >
;		> ?
public

 
decimal

 
DiscountPercentage

 )
{

* +
get

, /
;

/ 0
set

1 4
;

4 5
}

6 7
public 
bool 
IsActive 
{ 
get "
;" #
set$ '
;' (
}) *
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
	UpdatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} å
qC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\API\GraphQL\QueryTypes\PromotionQueryType.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
API !
.! "
GraphQL" )
.) *

QueryTypes* 4
{ 
public 

class 
PromotionQueryType #
{ 
	protected		 
PromotionQueryType		 $
(		$ %
)		% &
{

 	
} 	
public 
static 
async 
Task  
<  !
PromotionResponse! 2
>2 3(
GetPromotionGraphQLByIdAsync4 P
(P Q
GuidQ U
PromotionIdV a
,a b
[T U
ServiceU \
]\ ]
	IMediator^ g
mediatorh p
)p q
{ 	
return 
await 
mediator !
.! "
Send" &
(& '
new' *(
GetPromotionByIdGraphQLQuery+ G
(G H
PromotionIdH S
)S T
)T U
;U V
} 	
public 
static 
async 
Task  
<  !
List! %
<% &
PromotionResponse& 7
>7 8
>8 9(
GetAllPromotionsGraphQLAsync: V
(V W
[W X
ServiceX _
]_ `
	IMediatora j
mediatork s
)s t
{ 	
return 
await 
mediator !
.! "
Send" &
(& '
new' *'
GetAllPromotionGraphQLQuery+ F
(F G
)G H
)H I
;I J
} 	
} 
} É

ÉC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Responses\LoyaltyAccountResponse.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
	Responses9 B
{ 
public 

class "
LoyaltyAccountResponse '
{ 
public 
Guid 
LoyaltyAccountId $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
Guid 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 
Points 
{ 
get 
;  
set! $
;$ %
}& '
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
DateTime		 
	UpdatedAt		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
}

 
} ü

ÑC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Responses\CashbackAccountResponse.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
	Responses9 B
{ 
public 

sealed 
class #
CashbackAccountResponse /
{ 
public 
Guid 
CashbackAccountId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
Guid 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
decimal 
Balance 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
DateTime		 
	UpdatedAt		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
}

 
} „

ÑC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\ValidatePromotionRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class $
ValidatePromotionRequest 0
{ 
public 
Guid 
PromotionId 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
Guid 

CustomerId 
{  
get! $
;$ %
init& *
;* +
}, -
public 
decimal 
OrderTotalValue &
{' (
get) ,
;, -
init. 2
;2 3
}4 5
public

 
IReadOnlyCollection

 "
<

" #
Guid

# '
>

' (

ProductIds

) 3
{

4 5
get

6 9
;

9 :
init

; ?
;

? @
}

A B
= 
Array 
. 
Empty 
< 
Guid 
> 
(  
)  !
;! "
} 
} ∏
C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\RedeemPointsRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class 
RedeemPointsRequest +
{ 
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
) 
]  
public 
int 
Points 
{ 
get 
;  
set! $
;$ %
}& '
}		 
}

 ƒ
ÅC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\RedeemCashbackRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class !
RedeemCashbackRequest -
{ 
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue $
)$ %
]% &
public 
decimal 
Amount 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 Õ
lC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\API\Controllers\PromotionsController.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
API !
.! "
Controllers" -
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
PromotionsController

 %
:

& '
ControllerBase

( 6
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public  
PromotionsController #
(# $
	IMediator$ -
mediator. 6
)6 7
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
PromotionResponse' 8
>8 9
>9 :
CreatePromotion; J
(J K
[K L
FromBodyL T
]T U"
CreatePromotionCommandV l
commandm t
)t u
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
{ 
return 

BadRequest !
(! "

ModelState" ,
), -
;- .
} 
var 
promotionDto 
= 
await $
	_mediator% .
.. /
Send/ 3
(3 4
command4 ;
); <
;< =
return 

StatusCode 
( 
$num !
,! "
promotionDto# /
)/ 0
;0 1
} 	
[!! 	
HttpPost!!	 
(!! 
$str!! /
)!!/ 0
]!!0 1
public"" 
async"" 
Task"" 
<"" 
ActionResult"" &
>""& '
ActivatePromotion""( 9
(""9 :
["": ;
	FromRoute""; D
]""D E
Guid""F J
promotionId""K V
,""V W
CancellationToken## 
cancellationToken## +
)##+ ,
{$$ 	
var%% 
command%% 
=%% 
new%% $
ActivatePromotionCommand%% 6
(%%6 7
promotionId%%7 B
)%%B C
;%%C D
await'' 
	_mediator'' 
.'' 
Send''  
(''  !
command''! (
,''( )
cancellationToken''* ;
)''; <
;''< =
return)) 
	NoContent)) 
()) 
))) 
;)) 
}** 	
}++ 
},, ˆ
ÜC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\DeactivatePromotionRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class &
DeactivatePromotionRequest 2
{ 
public 
Guid 
PromotionId 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
string 
? 
Reason 
{ 
get  #
;# $
init% )
;) *
}+ ,
public 
DateTime 
DeactivatedAt %
{& '
get( +
;+ ,
init- 1
;1 2
}3 4
} 
}		 ”
ÇC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\CreatePromotionRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

class "
CreatePromotionRequest '
{ 
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
=		) *
string		+ 1
.		1 2
Empty		2 7
;		7 8
[ 	
Required	 
] 
public 
DateTime 
	StartDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
] 
public 
DateTime 
EndDate 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
decimal 
DiscountPercentage )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} »
áC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\CreateLoyaltyAccountRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

class '
CreateLoyaltyAccountRequest ,
{ 
[ 	
Required	 
] 
public 
Guid 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
}		 
}

 ﬁ
àC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\CreateCashbackAccountRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class (
CreateCashbackAccountRequest 4
{ 
[ 	
Required	 
] 
public 
Guid 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
}		 
}

 ∆
ÑC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Promotions\Application\Contracts\DTOs\Requests\ActivatePromotionRequest.cs
	namespace 	
SellGold
 
. 

Promotions 
. 
Application )
.) *
	Contracts* 3
.3 4
DTOs4 8
.8 9
Requests9 A
{ 
public 

sealed 
class $
ActivatePromotionRequest 0
{ 
public 
Guid 
PromotionId 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
DateTime 
ActivatedAt #
{$ %
get& )
;) *
init+ /
;/ 0
}1 2
} 
} 