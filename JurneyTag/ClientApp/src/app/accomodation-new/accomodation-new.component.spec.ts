import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccomodationNewComponent } from './accomodation-new.component';

describe('AccomodationNewComponent', () => {
  let component: AccomodationNewComponent;
  let fixture: ComponentFixture<AccomodationNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccomodationNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccomodationNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
