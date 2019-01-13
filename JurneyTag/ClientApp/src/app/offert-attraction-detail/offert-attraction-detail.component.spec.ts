import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OffertAttractionDetailComponent } from './offert-attraction-detail.component';

describe('OffertAttractionDetailComponent', () => {
  let component: OffertAttractionDetailComponent;
  let fixture: ComponentFixture<OffertAttractionDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OffertAttractionDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OffertAttractionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
