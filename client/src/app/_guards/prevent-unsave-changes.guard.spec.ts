import { TestBed } from '@angular/core/testing';

import { PreventUnsaveChangesGuard } from './prevent-unsave-changes.guard';

describe('PreventUnsaveChangesGuard', () => {
  let guard: PreventUnsaveChangesGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(PreventUnsaveChangesGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
