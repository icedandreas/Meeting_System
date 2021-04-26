# Meeting_System

Jeg har valgt at lave programmet i Entity Frameworks 6.
Brugte Github til version control.
Min applikation burde virke ved bare at køre programmet. Det kan evt. være at den henter nogle pakker først.
Der er brugere, møder og rum som kan vælges fra navigationsmenuen i toppen.
Man kan kun se møderne under møder, men kan lave og ændre brugere og rum under hver af dem samt se deres detaljer.
Der er lavet en tabel til at brugere skulle kunne se deres egne møder kun, men denne virker ikke. På samme måde er det også lavet sådan at der er en tabel til rum, så hvert rum kan se de møder som er skemalagt i rummet. Men dette virker heller ikke.
Når der oprettes nye møder, så tjekkes der for at der er nok kapacitet i lokalet til at alle brugerne kan være der, der tjekkes også for om mødet foregår engang i fremtiden. Der tjekkes desuden for om det valgte rum eksisterer. Dette skrives dog ikke ud til brugeren, men burde blive det. 
Inputtet til mødetidspunktet og møde varigheden er besværligt og skal optimeres. Tanken er at der skal anvendes en form for ”datepicker” så brugeren kan vælge dato og tidspunkt igennem en kalender gui i stedet for manuelt at skulle indtaste alting. Bruger dog allerede nogle pickers til forskelligt input.
Brugere har felter for telefon og E-mail, men disse anvendes ikke til noget. Men det vil være en god ting at bygge videre på, for at kunne sende notifikationer, og for at kunne synkronisere kalenderen med brugerens egen foretrukne E-mail kalender.
Der er ingen logning af problemer, hvilket også vil være en god ting i fremtiden.
Signupdate er automatisk sat til den nuværende dag.
Hvis et rum bliver slettet, så bliver alle møderne der hører til dette rum også slettet.
At lave koden mere asynkron ville være en god ting i fremtiden, især hvis det skulle køre på en server og benyttes af adskillige mennesker. Men siden dette kun kører lokalt for 1 bruger og ikke er en stor applikation har jeg ikke lagt fokus på dette. Dette vil dog også kunne give nogle samtidighedsproblemer (concurrency), som der skal tages stilling til.
Der er ingen check for at se om 2 møder overlapper hinanden enten med hensyn til at involvere de samme brugere, eller benytte det samme lokale.
