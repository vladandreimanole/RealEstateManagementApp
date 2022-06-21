import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantRentalsComponent } from './tenant-rentals.component';

describe('TenantRentalsComponent', () => {
  let component: TenantRentalsComponent;
  let fixture: ComponentFixture<TenantRentalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenantRentalsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TenantRentalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
