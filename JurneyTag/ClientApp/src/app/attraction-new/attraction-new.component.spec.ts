import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttractionNewComponent } from './attraction-new.component';

describe('AttractionNewComponent', () => {
  let component: AttractionNewComponent;
  let fixture: ComponentFixture<AttractionNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttractionNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttractionNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
