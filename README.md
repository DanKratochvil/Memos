Pro otestování projektu Enterprise jsem vytvořil služby TeamGenerator, která vygeneruje posádku (strom s vazbami), kde je možné zvolit kolik úrovní má posádka lodi (Maxlevel = 4), a kolik každý člen posádky může mít min (minChildrenCount = 1) a max podřízených (maxChildrenCount = 3).
Zobrazit vygenerovaný strom lze pomocí TeamDisplay, kde je na jednom řádku 1 člen posádky s nadřízeným (Parent) a podřízenými (Children). Uzly se vypisují rekurzivně jak byly generovány do hloubky, název X.Y znamená:
"C" - kapitán
X - číslo úrovně
Y - celkové pořadí vygenerovaného uzlu

Po spuštení aplikace se v konzoli takto vypíše po řádcích vygenerovaný strom, pak aplikace čeká na zadání jména nakaženého člena a pak vypíše:
-seznam podřízených nakaženého člena
-seznam všech nakažených členů, než se nákaza dostane ke kapitánovi
 

