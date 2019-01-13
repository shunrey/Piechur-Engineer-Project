import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OffertDetailComponent } from './offert-detail.component';

describe('OffertDetailComponent', () => {
  let component: OffertDetailComponent;
  let fixture: ComponentFixture<OffertDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OffertDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OffertDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
