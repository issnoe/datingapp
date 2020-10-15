# Angular Pattern 

## Diference bewen Promise & Observable

Observable can cancel 
Objertable is lazy 
Observable miltiple events



### Method promise

Note! check rxjs/operators

- susbribe 
- error
- ()=> After suscription end
- .toPromise() Return like a promise
- pipe
    map 
    reduce 
    ...?

In View async pipe

use async to handle the observable 

*ngFor="let x of getObservable() | async" {{x.attribute}}

## ReplaySubject

from rxjx

Object store in 

## Comunication Child Parent

using EventEmitters
Child
 @Output() cancelRegister = new EventEmitter();

Prent 
 cancelRegister($event)

## Angular Route Guard 