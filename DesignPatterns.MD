## 1. Factory Method Pattern - kreacijski pattern
	Su�tina ovog patterna je da podklase odlucuju koju klasu instancirati.
	Cilj je definisati interface za kreiranje objekta, medutim podklase ce odluciti �ta tacno instancirati. 
	Te podklase mogu na razlicite nacine da implementiraju interfejs.
	Ovaj pattern nije iskori�ten u na�em projektu. Mogao bi se iskoristiti prilikom logina, kada korisnik unese svoj username i password da tu implementiramo ovaj pattern tj. da se odluci da li instancirati VIP ili obicnog korisnika.

## 2. Iterator Pattern - patern pona�anja
	Ovaj patern omogucava sekvencijalni pristup elementima kolekcije bez da je poznato kakvi su  ti elementi interno. Ovaj patern nije iskori�ten u na�em projektu, ali bismo ga mogli iskoristiti prilikom prikazivanja reklama. Tada se prikazuje reklama bilo za event, bilo za promovisanu pjesmu bez da nam je potrebno da pravimo iterator posebno za pjesme posebno za eventove.

## 3. TemplateMethod Pattern - patern pona�anja
	TemplateMethod Pattern omogucava da se generalna ideja algoritma zadr�i, pri cemu neke dijelove algoritma mo�emo izdvojiti u odvojene 
	podklase te implementirati ih razlicito. Dakle struktura algoritma se ne mijenja. 
	Ovaj pattern nismo koristili u na�em projektu, ali bismo ga mogli iskoristiti pri obracunu cijene za reklamu. 
	Na primjer, da se na razlicit nacin obracunava vrijednost naplate za reklamu za event u odnosu na reklamu za pjesmu.