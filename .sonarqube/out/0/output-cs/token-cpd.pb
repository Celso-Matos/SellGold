ÿ*
KC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
. 
AddNewtonsoftJson 
( 
options 
=> !
{ 
options 
. 
SerializerSettings "
." #!
ReferenceLoopHandling# 8
=9 :

Newtonsoft; E
.E F
JsonF J
.J K!
ReferenceLoopHandlingK `
.` a
Ignorea g
;g h
} 
) 
; 
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
	AddScoped 
< 
IOrdersRepository ,
,, -$
SellGoldOrdersRepository. F
>F G
(G H
)H I
;I J
builder 
. 
Services 
. 
AddDbContext 
< !
SellGoldOrdersContext 3
>3 4
(4 5
options5 <
=>= ?
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C
$strC ]
)] ^
)^ _
)_ `
;` a
builder 
. 
Services 
. 
AddAutoMapper 
( 
cfg "
=># %
{ 
cfg   
.   

AddProfile   
<   
OrderProfileMapper   %
>  % &
(  & '
)  ' (
;  ( )
}!! 
)!! 
;!! 
builder$$ 
.$$ 
Services$$ 
.$$ 

AddMediatR$$ 
($$ 
typeof%% 

(%%
 
CreateOrderHandler%% 
)%% 
.%% 
Assembly%% '
)&& 
;&& 
builder)) 
.)) 
Services)) 
.** 
AddGraphQLServer** 
(** 
)** 
.++ 
AddQueryType++ 
<++ 
OrderQueryType++  
>++  !
(++! "
)++" #
.,, 
AddFiltering,, 
(,, 
),, 
.-- 

AddSorting-- 
(-- 
)-- 
;-- 
builder00 
.00 
Services00 
.00 
AddCors00 
(00 
options00  
=>00! #
{11 
options22 
.22 
	AddPolicy22 
(22 
$str22  
,22  !
policy33 
=>33 
policy33 
.33 
AllowAnyOrigin33 '
(33' (
)33( )
.44 
AllowAnyMethod44 '
(44' (
)44( )
.55 
AllowAnyHeader55 '
(55' (
)55( )
)55) *
;55* +
}66 
)66 
;66 
builder99 
.99 
Services99 
.99 

AddOpenApi99 
(99 
)99 
;99 
var;; 
app;; 
=;; 	
builder;;
 
.;; 
Build;; 
(;; 
);; 
;;; 
app>> 
.>> 
UseCors>> 
(>> 
$str>> 
)>> 
;>> 
appAA 
.AA 

MapGraphQLAA 
(AA 
$strAA 
)AA 
;AA 
voidDD 
ConfigureSwaggerUIDD 
(DD 
SwaggerUIOptionsDD (
cDD) *
)DD* +
{EE 
cFF 
.FF 
SwaggerEndpointFF 
(FF 
$strFF 0
,FF0 1
$strFF2 I
)FFI J
;FFJ K
cGG 
.GG 
RoutePrefixGG 
=GG 
$strGG 
;GG 
}HH 
ifJJ 
(JJ 
appJJ 
.JJ 
EnvironmentJJ 
.JJ 
IsDevelopmentJJ !
(JJ! "
)JJ" #
||JJ$ &
appJJ' *
.JJ* +
EnvironmentJJ+ 6
.JJ6 7
	IsStagingJJ7 @
(JJ@ A
)JJA B
)JJB C
{KK 
appLL 
.LL 

UseSwaggerLL 
(LL 
)LL 
;LL 
appMM 
.MM 
UseSwaggerUIMM 
(MM 
ConfigureSwaggerUIMM '
)MM' (
;MM( )
}NN 
appPP 
.PP 
UseHttpsRedirectionPP 
(PP 
)PP 
;PP 
appQQ 
.QQ 
UseAuthorizationQQ 
(QQ 
)QQ 
;QQ 
appRR 
.RR 
MapControllersRR 
(RR 
)RR 
;RR 
awaitTT 
appTT 	
.TT	 

RunAsyncTT
 
(TT 
)TT 
;TT §"
xC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Infrastructure\Repositories\SellGoldOrdersRepository.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Infrastructure (
.( )
Repositories) 5
{ 
public		 

class		 $
SellGoldOrdersRepository		 )
:		* +
IOrdersRepository		, =
{

 
private 
readonly !
SellGoldOrdersContext .
_context/ 7
;7 8
public $
SellGoldOrdersRepository '
(' (!
SellGoldOrdersContext( =
context> E
)E F
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
< 
Order 
>  
GetByIdAsync! -
(- .
Guid. 2
orderId3 :
): ;
{ 	
return 
await 
_context !
.! "
Orders" (
.( )
Include) 0
(0 1
o1 2
=>3 5
o6 7
.7 8

OrderItems8 B
)B C
.( )
FirstOrDefaultAsync) <
(< =
o= >
=>? A
oB C
.C D
OrderIdD K
==L N
orderIdO V
)V W
??X Z
throw[ `
newa d#
InfrastructureExceptione |
(| }
$"} 
$str	 Ü
{
Ü á
orderId
á é
}
é è
$str
è ü
"
ü †
)
† °
;
° ¢
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
Order& +
>+ ,
>, -
GetAllAsync. 9
(9 :
): ;
{ 	
return 
await 
_context !
.! "
Orders" (
.( )
Include) 0
(0 1
o1 2
=>3 5
o6 7
.7 8

OrderItems8 B
)B C
.C D
ToListAsyncD O
(O P
)P Q
;Q R
} 	
public 
async 
Task 
AddAsync "
(" #
Order# (
order) .
). /
{ 	
await 
_context 
. 
Orders !
.! "
AddAsync" *
(* +
order+ 0
)0 1
;1 2
await 
_context 
. 
SaveChangesAsync +
(+ ,
), -
;- .
} 	
public 
async 
Task 
UpdateAsync %
(% &
Order& +
order, 1
)1 2
{   	
_context!! 
.!! 
Entry!! 
(!! 
order!!  
)!!  !
.!!! "
State!!" '
=!!( )
EntityState!!* 5
.!!5 6
Modified!!6 >
;!!> ?
await"" 
_context"" 
."" 
SaveChangesAsync"" +
(""+ ,
)"", -
;""- .
}## 	
public$$ 
async$$ 
Task$$ 
DeleteAsync$$ %
($$% &
Guid$$& *
orderId$$+ 2
)$$2 3
{%% 	
var&& 
order&& 
=&& 
await&& 
_context&& &
.&&& '
Orders&&' -
.&&- .
	FindAsync&&. 7
(&&7 8
orderId&&8 ?
)&&? @
;&&@ A
if'' 
('' 
order'' 
!='' 
null'' 
)'' 
{(( 
_context)) 
.)) 
Orders)) 
.))  
Remove))  &
())& '
order))' ,
))), -
;))- .
await** 
_context** 
.** 
SaveChangesAsync** /
(**/ 0
)**0 1
;**1 2
}++ 
},, 	
}-- 
}.. í
uC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Infrastructure\Exceptions\InfrastructureException.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Infrastructure (
.( )

Exceptions) 3
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
} ¥8
C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Infrastructure\Data\Migrations\20251216151307_InitialCreate.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Infrastructure (
.( )
Data) -
.- .

Migrations. 8
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
$str 
, 
columns 
: 
table 
=> !
new" %
{ 
OrderId 
= 
table #
.# $
Column$ *
<* +
Guid+ /
>/ 0
(0 1
type1 5
:5 6
$str7 I
,I J
nullableK S
:S T
falseU Z
)Z [
,[ \

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
,^ _
Date 
= 
table  
.  !
Column! '
<' (
DateTime( 0
>0 1
(1 2
type2 6
:6 7
$str8 C
,C D
nullableE M
:M N
falseO T
)T U
,U V
Status 
= 
table "
." #
Column# )
<) *
int* -
>- .
(. /
type/ 3
:3 4
$str5 :
,: ;
nullable< D
:D E
falseF K
)K L
,L M
	CreatedAt 
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
,Z [
	UpdatedAt 
= 
table  %
.% &
Column& ,
<, -
DateTime- 5
>5 6
(6 7
type7 ;
:; <
$str= H
,H I
nullableJ R
:R S
falseT Y
)Y Z
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 0
,0 1
x2 3
=>4 6
x7 8
.8 9
OrderId9 @
)@ A
;A B
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str "
," #
columns   
:   
table   
=>   !
new  " %
{!! 
OrderItemId"" 
=""  !
table""" '
.""' (
Column""( .
<"". /
Guid""/ 3
>""3 4
(""4 5
type""5 9
:""9 :
$str""; M
,""M N
nullable""O W
:""W X
false""Y ^
)""^ _
,""_ `
	ProductId## 
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
,##] ^
Quantity$$ 
=$$ 
table$$ $
.$$$ %
Column$$% +
<$$+ ,
int$$, /
>$$/ 0
($$0 1
type$$1 5
:$$5 6
$str$$7 <
,$$< =
nullable$$> F
:$$F G
false$$H M
)$$M N
,$$N O
	UnitPrice%% 
=%% 
table%%  %
.%%% &
Column%%& ,
<%%, -
decimal%%- 4
>%%4 5
(%%5 6
type%%6 :
:%%: ;
$str%%< K
,%%K L
nullable%%M U
:%%U V
false%%W \
)%%\ ]
,%%] ^
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
,&&Z [
	UpdatedAt'' 
='' 
table''  %
.''% &
Column''& ,
<'', -
DateTime''- 5
>''5 6
(''6 7
type''7 ;
:''; <
$str''= H
,''H I
nullable''J R
:''R S
false''T Y
)''Y Z
,''Z [
OrderId(( 
=(( 
table(( #
.((# $
Column(($ *
<((* +
Guid((+ /
>((/ 0
(((0 1
type((1 5
:((5 6
$str((7 I
,((I J
nullable((K S
:((S T
true((U Y
)((Y Z
})) 
,)) 
constraints** 
:** 
table** "
=>**# %
{++ 
table,, 
.,, 

PrimaryKey,, $
(,,$ %
$str,,% 4
,,,4 5
x,,6 7
=>,,8 :
x,,; <
.,,< =
OrderItemId,,= H
),,H I
;,,I J
table-- 
.-- 

ForeignKey-- $
(--$ %
name.. 
:.. 
$str.. <
,..< =
column// 
:// 
x//  !
=>//" $
x//% &
.//& '
OrderId//' .
,//. /
principalTable00 &
:00& '
$str00( 0
,000 1
principalColumn11 '
:11' (
$str11) 2
)112 3
;113 4
}22 
)22 
;22 
migrationBuilder44 
.44 
CreateIndex44 (
(44( )
name55 
:55 
$str55 -
,55- .
table66 
:66 
$str66 #
,66# $
column77 
:77 
$str77 !
)77! "
;77" #
}88 	
	protected;; 
override;; 
void;; 
Down;;  $
(;;$ %
MigrationBuilder;;% 5
migrationBuilder;;6 F
);;F G
{<< 	
migrationBuilder== 
.== 
	DropTable== &
(==& '
name>> 
:>> 
$str>> "
)>>" #
;>># $
migrationBuilder@@ 
.@@ 
	DropTable@@ &
(@@& '
nameAA 
:AA 
$strAA 
)AA 
;AA  
}BB 	
}CC 
}DD ¥	
uC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Infrastructure\Data\Context\SellGoldOrdersContext.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Infrastructure (
.( )
Data) -
.- .
Context. 5
{ 
public 

class !
SellGoldOrdersContext &
:' (
	DbContext) 2
{ 
public !
SellGoldOrdersContext $
($ %
DbContextOptions% 5
<5 6!
SellGoldOrdersContext6 K
>K L
optionsM T
)T U
:V W
baseX \
(\ ]
options] d
)d e
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
 
Order

 
>

 
Orders

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
public 
DbSet 
< 
	OrderItem 
> 

OrderItems  *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} ‚
eC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Domain\Exceptions\DomainException.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Domain  
.  !

Exceptions! +
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
} ≠
]C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Domain\Entities\OrderItem.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Domain  
.  !
Entities! )
{ 
public 

class 
	OrderItem 
{ 
	protected 
	OrderItem 
( 
) 
{ 
}  !
public		 
	OrderItem		 
(		 
Guid		 
	productId		 '
,		' (
int		) ,
quantity		- 5
,		5 6
decimal		7 >
	unitPrice		? H
)		H I
{

 	
if 
( 
quantity 
<= 
$num 
) 
throw 
new 
DomainException )
() *
$str* @
)@ A
;A B
if 
( 
	unitPrice 
<= 
$num 
) 
throw 
new 
DomainException )
() *
$str* ;
); <
;< =
	ProductId 
= 
	productId !
;! "
Quantity 
= 
quantity 
;  
	UnitPrice 
= 
	unitPrice !
;! "
} 	
public 
Guid 
	ProductId 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 
int 
Quantity 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 
decimal 
	UnitPrice  
{! "
get# &
;& '
private( /
set0 3
;3 4
}5 6
public 
decimal 
Total 
=> 
Quantity  (
*) *
	UnitPrice+ 4
;4 5
} 
} ¿
\C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Domain\Enums\OrderStatus.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Domain  
.  !
Enums! &
{ 
public 

enum 
OrderStatus 
{ 
Open 
, 
Paid 
, 
Canceled 
} 
}		 Á/
YC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Domain\Entities\Order.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Domain  
.  !
Entities! )
{ 
public 

class 
Order 
{ 
private 
readonly 
List 
< 
	OrderItem '
>' (
_items) /
=0 1
new2 5
(5 6
)6 7
;7 8
	protected

 
Order

 
(

 
)

 
{

 
}

 
public 
Order 
( 
Guid 

customerId $
,$ %
IEnumerable& 1
<1 2
	OrderItem2 ;
>; <
items= B
,B C
DateTimeD L
	orderDateM V
)V W
{ 	
if 
( 

customerId 
== 
Guid "
." #
Empty# (
)( )
throw 
new 
ArgumentException +
(+ ,
$str, B
)B C
;C D
if 
( 
items 
== 
null 
||  
!! "
items" '
.' (
Any( +
(+ ,
), -
)- .
throw 
new 
DomainException )
() *
$str* R
)R S
;S T
OrderId 
= 
Guid 
. 
NewGuid "
(" #
)# $
;$ %

CustomerId 
= 

customerId #
;# $
Date 
= 
	orderDate 
; 
Status 
= 
OrderStatus  
.  !
Open! %
;% &
_items 
. 
AddRange 
( 
items !
)! "
;" #
	CreatedAt 
= 
DateTime  
.  !
UtcNow! '
;' (
	UpdatedAt 
= 
DateTime  
.  !
UtcNow! '
;' (
} 	
public 
Guid 
OrderId 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public   
Guid   

CustomerId   
{    
get  ! $
;  $ %
private  & -
set  . 1
;  1 2
}  3 4
public!! 
DateTime!! 
Date!! 
{!! 
get!! "
;!!" #
private!!$ +
set!!, /
;!!/ 0
}!!1 2
public## 
OrderStatus## 
Status## !
{##" #
get##$ '
;##' (
private##) 0
set##1 4
;##4 5
}##6 7
public%% 
IReadOnlyCollection%% "
<%%" #
	OrderItem%%# ,
>%%, -

OrderItems%%. 8
=>%%9 ;
_items%%< B
.%%B C

AsReadOnly%%C M
(%%M N
)%%N O
;%%O P
public'' 
decimal'' 

TotalValue'' !
=>''" $
_items''% +
.''+ ,
Sum'', /
(''/ 0
i''0 1
=>''2 4
i''5 6
.''6 7
Total''7 <
)''< =
;''= >
public)) 
DateTime)) 
	CreatedAt)) !
{))" #
get))$ '
;))' (
private))) 0
set))1 4
;))4 5
}))6 7
public** 
DateTime** 
	UpdatedAt** !
{**" #
get**$ '
;**' (
private**) 0
set**1 4
;**4 5
}**6 7
public00 
void00 
Pay00 
(00 
)00 
{11 	
if22 
(22 
Status22 
==22 
OrderStatus22 %
.22% &
Canceled22& .
)22. /
throw33 
new33 
DomainException33 )
(33) *
$str33* O
)33O P
;33P Q
if55 
(55 
Status55 
==55 
OrderStatus55 %
.55% &
Paid55& *
)55* +
throw66 
new66 
DomainException66 )
(66) *
$str66* ?
)66? @
;66@ A
Status88 
=88 
OrderStatus88  
.88  !
Paid88! %
;88% &
Touch99 
(99 
)99 
;99 
}:: 	
public<< 
void<< 
Cancel<< 
(<< 
)<< 
{== 	
if>> 
(>> 
Status>> 
==>> 
OrderStatus>> %
.>>% &
Paid>>& *
)>>* +
throw?? 
new?? 
DomainException?? )
(??) *
$str??* O
)??O P
;??P Q
StatusAA 
=AA 
OrderStatusAA  
.AA  !
CanceledAA! )
;AA) *
TouchBB 
(BB 
)BB 
;BB 
}CC 	
publicEE 
voidEE 
AddItemEE 
(EE 
	OrderItemEE %
itemEE& *
)EE* +
{FF 	
ifGG 
(GG 
StatusGG 
!=GG 
OrderStatusGG %
.GG% &
OpenGG& *
)GG* +
throwHH 
newHH 
DomainExceptionHH )
(HH) *
$strHH* Z
)HHZ [
;HH[ \
_itemsJJ 
.JJ 
AddJJ 
(JJ 
itemJJ 
)JJ 
;JJ 
TouchKK 
(KK 
)KK 
;KK 
}LL 	
privateNN 
voidNN 
TouchNN 
(NN 
)NN 
{OO 	
	UpdatedAtPP 
=PP 
DateTimePP  
.PP  !
UtcNowPP! '
;PP' (
}QQ 	
}RR 
}SS “
xC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Queries\GraphQL\GetOrderByIdGraphQLQuery.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Queries& -
.- .
GraphQL. 5
{ 
public 

record $
GetOrderByIdGraphQLQuery *
(* +
Guid+ /
OrderId0 7
)7 8
:9 :
IRequest; C
<C D
OrderResponseD Q
>Q R
;R S
} ⁄
xC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Queries\GraphQL\GetAllOrdersGraphQLQuery.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Queries& -
.- .
GraphQL. 5
{ 
public 

class $
GetAllOrdersGraphQLQuery )
() *
)* +
:, -
IRequest. 6
<6 7
List7 ;
<; <
OrderResponse< I
>I J
>J K
;K L
} ¨	
yC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Interfaces\Repositories\IOrdersRepository.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &

Interfaces& 0
.0 1
Repositories1 =
{ 
public 

	interface 
IOrdersRepository &
{ 
Task 
< 
Order 
> 
GetByIdAsync  
(  !
Guid! %
orderId& -
)- .
;. /
Task 
< 
IEnumerable 
< 
Order 
> 
>  
GetAllAsync! ,
(, -
)- .
;. /
Task 
AddAsync 
( 
Order 
order !
)! "
;" #
Task		 
UpdateAsync		 
(		 
Order		 
order		 $
)		$ %
;		% &
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
 
orderId

 %
)

% &
;

& '
} 
} ™
rC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Handlers\Orders\CreateOrderHandler.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Handlers& .
.. /
Orders/ 5
{		 
public

 

class

 
CreateOrderHandler

 #
:

$ %
IRequestHandler

& 5
<

5 6
CreateOrderCommand

6 H
,

H I
OrderResponse

J W
>

W X
{ 
private 
readonly 
IOrdersRepository *
_ordersRepository+ <
;< =
private 
readonly 
IMapper  
_mapper! (
;( )
public 
CreateOrderHandler !
(! "
IOrdersRepository" 3
ordersRepository4 D
,D E
IMapperF M
mapperN T
)T U
{ 	
_ordersRepository 
= 
ordersRepository  0
;0 1
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
OrderResponse '
>' (
Handle) /
(/ 0
CreateOrderCommand0 B
commandC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 	
var 
order 
= 
_mapper 
.  
Map  #
<# $
Order$ )
>) *
(* +
command+ 2
.2 3
createOrderRequest3 E
)E F
;F G
await 
_ordersRepository #
.# $
AddAsync$ ,
(, -
order- 2
)2 3
;3 4
var 
response 
= 
_mapper "
." #
Map# &
<& '
OrderResponse' 4
>4 5
(5 6
order6 ;
); <
;< =
return 
response 
; 
} 	
}   
}!! ·
{C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Handlers\GraphQL\GetOrderByIdGraphQLHandler.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Handlers& .
.. /
GraphQL/ 6
{		 
public

 

class

 &
GetOrderByIdGraphQLHandler

 +
:

, -
IRequestHandler

. =
<

= >$
GetOrderByIdGraphQLQuery

> V
,

V W
OrderResponse

X e
>

e f
{ 
private 
readonly 
IOrdersRepository *
_ordersRepository+ <
;< =
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
public &
GetOrderByIdGraphQLHandler )
() *
IOrdersRepository* ;
ordersRepository< L
,L M
IMapperN U
mapperV \
,\ ]
ILogger^ e
<e f'
GetOrderByIdGraphQLHandler	f Ä
>
Ä Å
logger
Ç à
)
à â
{ 	
_ordersRepository 
= 
ordersRepository  0
;0 1
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
< 
OrderResponse '
>' (
Handle) /
(/ 0$
GetOrderByIdGraphQLQuery0 H
queryI N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 	
var 
order 
= 
await 
_ordersRepository /
./ 0
GetByIdAsync0 <
(< =
query= B
.B C
OrderIdC J
)J K
;K L
if 
( 
order 
== 
null 
) 
{ 
	OrderLogs 
. 
OrderNotFound '
(' (
_logger( /
,/ 0
query1 6
.6 7
OrderId7 >
)> ?
;? @
throw 
new 
NotFoundException +
(+ ,
$str, 4
,4 5
query6 ;
.; <
OrderId< C
)C D
;D E
} 
var 
response 
= 
_mapper "
." #
Map# &
<& '
OrderResponse' 4
>4 5
(5 6
order6 ;
); <
;< =
return!! 
response!! 
;!! 
}"" 	
}## 
}$$ ú
{C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Handlers\GraphQL\GetAllOrdersGraphQLHandler.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Handlers& .
.. /
GraphQL/ 6
{ 
public		 

class		 &
GetAllOrdersGraphQLHandler		 +
:		, -
IRequestHandler		. =
<		= >$
GetAllOrdersGraphQLQuery		> V
,		V W
List		X \
<		\ ]
OrderResponse		] j
>		j k
>		k l
{

 
private 
readonly 
IOrdersRepository *
_ordersRepository+ <
;< =
private 
readonly 
IMapper  
_mapper! (
;( )
public &
GetAllOrdersGraphQLHandler )
() *
IOrdersRepository* ;
ordersRepository< L
,L M
IMapperN U
mapperV \
)\ ]
{ 	
_ordersRepository 
= 
ordersRepository  0
;0 1
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
< 
OrderResponse ,
>, -
>- .
Handle/ 5
(5 6$
GetAllOrdersGraphQLQuery6 N
queryO T
,T U
CancellationTokenV g
cancellationTokenh y
)y z
{ 	
var 
order 
= 
await 
_ordersRepository /
./ 0
GetAllAsync0 ;
(; <
)< =
;= >
return 
_mapper 
. 
Map 
< 
List #
<# $
OrderResponse$ 1
>1 2
>2 3
(3 4
order4 9
)9 :
;: ;
} 	
} 
} ˚
tC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Contracts\Mappers\OrderProfileMapper.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
	Contracts& /
./ 0
Mappers0 7
{ 
public 

class 
OrderProfileMapper #
:$ %
Profile& -
{		 
public

 
OrderProfileMapper

 !
(

! "
)

" #
{ 	
	CreateMap 
< 
CreateOrderRequest (
,( )
Order* /
>/ 0
(0 1
)1 2
. 
ConstructUsing 
(  
src  #
=>$ &
new 
Order 
( 
src 
. 

CustomerId &
,& '
src 
. 
Items !
.! "
Select" (
(( )
i) *
=>+ -
new 
	OrderItem  )
() *
i* +
.+ ,
	ProductId, 5
,5 6
i7 8
.8 9
Quantity9 A
,A B
iC D
.D E
	UnitPriceE N
)N O
)O P
,P Q
src 
. 
	OrderDate %
??& (
DateTime) 1
.1 2
UtcNow2 8
) 
) 
; 
	CreateMap 
< 
Order 
, 
OrderResponse *
>* +
(+ ,
), -
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Status( .
,. /
opt0 3
=>4 6
opt 
. 
MapFrom 
(  
src  #
=>$ &
src' *
.* +
Status+ 1
.1 2
ToString2 :
(: ;
); <
)< =
)= >
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (

TotalValue( 2
,2 3
opt4 7
=>8 :
opt 
. 
MapFrom 
(  
src  #
=>$ &
src' *
.* +

TotalValue+ 5
)5 6
)6 7
;7 8
	CreateMap 
< 
	OrderItem 
,  
OrderItemResponse! 2
>2 3
(3 4
)4 5
;5 6
} 	
} 
}   
vC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Contracts\DTOs\Responses\OrderResponse.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
	Contracts& /
./ 0
DTOs0 4
.4 5
	Responses5 >
{ 
public 

class 
OrderResponse 
{ 
[ 	
JsonPropertyName	 
( 
$str #
)# $
]$ %
public 
Guid 
OrderId 
{ 
get !
;! "
set# &
;& '
}( )
[

 	
JsonPropertyName

	 
(

 
$str

 &
)

& '
]

' (
public 
Guid 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
JsonPropertyName	 
( 
$str  
)  !
]! "
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
JsonPropertyName	 
( 
$str "
)" #
]# $
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
[ 	
JsonPropertyName	 
( 
$str &
)& '
]' (
public 
decimal 

TotalValue !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
JsonPropertyName	 
( 
$str !
)! "
]" #
public 
List 
< 
OrderItemResponse %
>% &
Items' ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
=; <
new= @
(@ A
)A B
;B C
[ 	
JsonPropertyName	 
( 
$str %
)% &
]& '
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
JsonPropertyName	 
( 
$str %
)% &
]& '
public 
DateTime 
	UpdatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
}"" …
zC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Contracts\DTOs\Responses\OrderItemResponse.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
	Contracts& /
./ 0
DTOs0 4
.4 5
	Responses5 >
{ 
public 

class 
OrderItemResponse "
{ 
public 
Guid 
	ProductId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public		 
decimal		 
	UnitPrice		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public

 
decimal

 
Total

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
} 
} ñ
zC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Contracts\DTOs\Requests\CreateOrderRequest.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
	Contracts& /
./ 0
DTOs0 4
.4 5
Requests5 =
{ 
public 

class 
CreateOrderRequest #
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ;
); <
]< =
public 
Guid 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
[

 	
Required

	 
(

 
ErrorMessage

 
=

  
$str

! G
)

G H
]

H I
[ 	
	MinLength	 
( 
$num 
, 
ErrorMessage "
=# $
$str% M
)M N
]N O
public 
List 
< "
CreateOrderItemRequest *
>* +
Items, 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
=@ A
newB E
(E F
)F G
;G H
public 
DateTime 
? 
	OrderDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} €
~C:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Contracts\DTOs\Requests\CreateOrderItemRequest.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
	Contracts& /
./ 0
DTOs0 4
.4 5
Requests5 =
{ 
public 

class "
CreateOrderItemRequest '
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ;
); <
]< =
public 
Guid 
	ProductId 
{ 
get  #
;# $
set% (
;( )
}* +
[

 	
Range

	 
(

 
$num

 
,

 
int

 
.

 
MaxValue

 
,

 
ErrorMessage

  ,
=

- .
$str

/ V
)

V W
]

W X
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Range	 
( 
typeof 
( 
decimal 
) 
, 
$str  #
,# $
$str% D
,D E
ErrorMessageF R
=S T
$str	U Ä
)
Ä Å
]
Å Ç
public 
decimal 
	UnitPrice  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} ’
aC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Commons\OrderLogs.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Commons& -
{ 
internal 
static 
partial 
class !
	OrderLogs" +
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
$str 3
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
 "
OrderNotFound

# 0
(

0 1
ILogger 
logger 
, 
Guid 
orderId 
) 
; 
} 
} Ô
iC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Commons\NotFoundException.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Commons& -
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
 â
eC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Commons\ExceptionBase.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Commons& -
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
} µ
kC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\Application\Commands\CreateOrderCommand.cs
	namespace 	
SellGold
 
. 
Orders 
. 
Application %
.% &
Commands& .
{ 
public 

record 
CreateOrderCommand $
($ %
CreateOrderRequest% 7
createOrderRequest8 J
)J K
:L M
IRequestN V
<V W
OrderResponseW d
>d e
;e f
} €
iC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\API\GraphQL\QueryTypes\OrderQueryType.cs
	namespace 	
SellGold
 
. 
Orders 
. 
API 
. 
GraphQL %
.% &

QueryTypes& 0
{ 
public 

class 
OrderQueryType 
{ 
	protected		 
OrderQueryType		  
(		  !
)		! "
{

 	
} 	
public 
static 
async 
Task  
<  !
OrderResponse! .
>. /&
GetProductGraphQLByIdAsync0 J
(J K
GuidK O
OrderIdP W
,W X
[H I
ServiceI P
]P Q
	IMediatorR [
mediator\ d
)d e
{ 	
return 
await 
mediator !
.! "
Send" &
(& '
new' *$
GetOrderByIdGraphQLQuery+ C
(C D
OrderIdD K
)K L
)L M
;M N
} 	
public 
static 
async 
Task  
<  !
List! %
<% &
OrderResponse& 3
>3 4
>4 5$
GetAllOrdersGraphQLAsync6 N
(N O
[ 
Service 
] 
	IMediator 
mediator  (
)( )
{ 	
return 
await 
mediator !
.! "
Send" &
(& '
new' *$
GetAllOrdersGraphQLQuery+ C
(C D
)D E
)E F
;F G
} 	
} 
} É
dC:\Users\Celso Matos Costa\source\repos\SellGold\SellGold.Orders\API\Controllers\OrdersController.cs
	namespace 	
SellGold
 
. 
Orders 
. 
API 
. 
Controllers )
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
OrdersController

 !
:

" #
ControllerBase

$ 2
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
OrdersController 
(  
	IMediator  )
mediator* 2
)2 3
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
<& '
OrderResponse' 4
>4 5
>5 6
CreateOrder7 B
(B C
[C D
FromBodyD L
]L M
CreateOrderCommandN `
commanda h
)h i
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
var 
orderDto 
= 
await  
	_mediator! *
.* +
Send+ /
(/ 0
command0 7
)7 8
;8 9
return 

StatusCode 
( 
$num !
,! "
orderDto# +
)+ ,
;, -
} 	
} 
} 