import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccomodationRoomComponent } from './accomodation-room.component';

describe('AccomodationRoomComponent', () => {
  let component: AccomodationRoomComponent;
  let fixture: ComponentFixture<AccomodationRoomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccomodationRoomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccomodationRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
