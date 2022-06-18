import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentalsListComponent } from './rentals-list.component';

describe('RentalsListComponent', () => {
  let component: RentalsListComponent;
  let fixture: ComponentFixture<RentalsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RentalsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RentalsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
