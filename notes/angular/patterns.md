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

\*ngFor="let x of getObservable() | async" {{x.attribute}}

## ReplaySubject

from rxjx

Object store in

## Comunication Child Parent

using EventEmitters
Child
@Output() cancelRegister = new EventEmitter();

Prent
cancelRegister(\$event)

## rxjs

{ of } from 'rxjs';

usefull to reurn a Observable

```ts
 getMembers() {
    //Of return like an Objesvable
    if (this.members.length > 0) return of(this.members);
    return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
      map((members) => {
        this.members = members;
        return members;
      })
    );
  }
```

## Async pipe

Persist data in services and

```ts
  members$: Observable<Member[]>;

  constructor(private memberService: MembersService) {}

  ngOnInit(): void {
    this.members$ = this.memberService.getMembers();
  }
```

```html
<div *ngFor="let member of members$ | async" class="col-2">
  <app-member-card [member]="member"></app-member-card>
</div>
```
