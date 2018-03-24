# Grupa 10 Tim - Undefined

## **Tema: MusicBox**

## **Članovi tima:**
1. Nermin Krdžić
2. Emir Šehović

## **Opis teme**

###### Glavni fokus MusicBox aplikacije je omogućavanje korisnicima pristup raznim vrstama pjesama. Mnogi vole da slušaju muziku dok uče, bave se nekom fizičkom aktivnosti ili čisto radi relaksacije. Ova aplikacija će im to pružiti. Korisnici mogu odabrati sebi omiljene pjesme ili razvrstati ih u liste koje slušaju ovisno o aktivnosti koju rade ili u kojem su raspoloženju te tako jednostavno odabrati koju muziku žele slušati. Međutim, može nam dosaditi čak i naša omiljena pjesma te tada korisnici mogu istražiti neki potpuno novi tip muzike ili mogu zatražiti da im aplikacija preporuči neke nove pjesme slične onima koje su korisniku omiljene. Također, MusicBox podstiče korisnike na kreativnost te im omogućava i uploadovanje njihovih vlastitih djela na koja mogu dobiti feedback od ostalih korisnika u vidu ocjene i/ili komentara. Nekada fanovima muzike nije dovoljno čisto slušanje muzike kroz slušalice te tada mogu posjetiti profil svojih omiljenih izvođača i provjeriti da li imaju organizovan neki događaj kao i dobiti informacije o tom događaju. 



## **Procesi**

###### **Registracija** 
Korisnik unosi svoje podatke (ime,prezime, e-mail, korisnicko ime, sifru), zatim se vrsi validacija podataka. U slucaju da validacija ne prodje korinik mora unijeti validne podatke. Ako je validacija prosla kreira se korisnicki profil (account), i korisnik je u stanju da pravi svoje liste pjesama, da ocjenjuje i/ili komentarise djela drugih korisnika ukljucujuci i mogucnosti koje su date "guest" korisniku.  

###### **Menadzment profila i prijava na profil**
Korisnik se može prijaviti na svoj profil tako što unosi svoje korisničko ime i šifru. Ukoliko je uneseno ispravno korisničko ime i šifra pristupa dalje aplikaciji, a u suprotnom mu se javlja greška. Nakon otvaranja svog profila u postavkama može mijenjati postavke/informacije svog računa

###### **Preoporuka pjesama**
Nakon što korisnik zatraži preporuku pjesama sistem će analizirati njegove najslušanije pjesme te na osnovu toga filtrirati pjesme iz baze podataka te sastaviti listu pjesama za korisnika

###### **Pretrazivanje pjesama i dodavanje u playlist**
Korisnik se odlucuje na jednu od vise mogucih nacina pretrage. Moze odabrati pretragu po filterima poput ime pjesm / izvođača ili po žanru. Umjesto toga može se odlučiti i za pretragu top pjesama. Nakon ovoga se korisniku prikazuje lista pjesama koja zadovoljava date kriterije. Dodatno moze se odluciti da doda neku pjesmu u playlistu te nakon toga mu se prikazuje lista njegovih playlista te odabire u koji playlist je zeli dodati ili moze odustati te se vraca na prikazanu listu pjesama

###### **Promovisanje**
VIP korisnici mogu rezervisati (ukoliko nisu već svi slotovi zauzeti) mjesto na promotivnom tabu aplikacije. Prilikom rezervisanja slota za reklamiranje korisnik odabire pjesmu ili event koji želi da promoviše, odabire vremenski period na koji želi da to promoviše (max 7 dana) i eventualno dodaje dodatni tekst na reklamu. Nakon toga se obračunava svota koja se naplaćuje za tu reklamu. Nakon toga drugi korisnici promovisani sadržaj pronalaze u posvećenom dijelu aplikacije te klik na reklamu ih dovodi na tu pjesmu/događaj.

###### **Upload pjesama**
Korisnik odabire pjesmu koju zeli da upload-uje, Nakon cega pise naziv pjesme, tip zanra, da li zeli dopustiti komentare na svoju pjesmu, i na kraju stavlja svoj komentar (ako hoce), i vrsi upload na aplikaciju. 

## **Funkcionalnosti**

######
**Svi korisnici**
- Mogucnost slusanja raznih vrsta pjesama
- Mogucnost pretrage pjesama po nazivu pjesme
- Mogucnost pretrage pjesama po nazivu izvodjaca
- Mogucnost pretrage pjesama po zanru
- Mogucnost pracenja najnovijihv (novododanih) pjesama

**Gost korisnici**
- Mogucnost registracije

**Svi registrovani korisnici**
- Mogucnost pretrage pjesama preporukom
- Mogucnost kreiranja privatne play-liste
- Mogucnost pracenja najpreslusnijih pjesama
- Mogucnost ocjenjivanja pjesama
- Mogucnost ostavljanja komentara nad pjesmama
- Mogucnost pregleda event-a drugih korisnika

**Obicni reistrovani korisnici**
- Mogucnost nadograđivanja računa na VIP

**VIP registrovani korisnici**
- Mogucnost upload-a sopstvenih pjesama
- Mogucnost dodavanja event-a
- Mogucnost rezervisanja reklame za pjesmu ili event

## **Akteri**

######
- Korisnik - svaki korisnik ima mogućnost pretraživanja pjesama po nazivu pjesme, izvođača ili po žanru te pregled najslušanijih pjesama
   - Neregistrovani / guest korisnik - dodatno ovaj tip korisnika ima mogućnost registracije
   - Registrovani korisnik - ima mogućnost pretrage pjesama po preporuci, kreiranja playlisti, ocjenjivanja/komentarisanja pjesama i pregled tuđih profila i eventova 
      - Obični registrovani - ima još i mogućnost nadogradnje računa na VIP 
      - VIP korisnik  - još ima i mogućnost uploadovanja vlastitih pjesama, promovisanja tih pjesama te dodavanja eventova. 
- Administrator sistema - administrator sistema ima mogućnost uklanjanja bugova u aplikaciji, ažuriranje aplikacije, banovanje i brisanje korisničkih računa