import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccomodationAlimentationComponent } from './accomodation-alimentation.component';

describe('AccomodationAlimentationComponent', () => {
  let component: AccomodationAlimentationComponent;
  let fixture: ComponentFixture<AccomodationAlimentationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccomodationAlimentationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccomodationAlimentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
