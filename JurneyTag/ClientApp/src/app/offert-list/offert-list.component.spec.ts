import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OffertListComponent } from './offert-list.component';

describe('OffertListComponent', () => {
  let component: OffertListComponent;
  let fixture: ComponentFixture<OffertListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OffertListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OffertListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
