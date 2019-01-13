import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OffertNewComponent } from './offert-new.component';

describe('OffertNewComponent', () => {
  let component: OffertNewComponent;
  let fixture: ComponentFixture<OffertNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OffertNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OffertNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
