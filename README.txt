S00131154 Oisin Foley CA2 09/12/14


The effort shown is down to a mix of poor timekeeping and getting struck down with tonsilitis at the wrong time.
Unfortuntely one assignment had to take a hit and this was it. Fortunately for me there's a final
exam in which I aim to redeem myself.

In saying that I had made more than a start some time ago, even though most of this is a last minute job, but I lost a lot of time trying to get the model to compile and run (see below for more info). 
Eventually by looking at the inner exception property at runtime I could see that entity framework was looking for a 
'datetime2' datatype for some of my datetime properties as opposed to just 'datetime, whether
or not this was through my own doing I don't know but either way I got it fixed by declaring 
the column type as that when declaring properties within the class.

I ended up separating Movie, Actor, MovieActor, the DBcntext and seeding class to help figure out
where my problem was coming from. I needed to do this as I was being given a 'MinTicks' and 'MaxTicks'
out of range exception on the line which created a list to hold my movies and obviously it wasn't that one line
that was causing it to complain.


Application can: 
- add/edit/delete
- filter by start date(when movie was released)
- made use of toast

Anyways, it's late and i'm not sure if this is sort of format for a README will suffice, but I said i'd explain myself at least.