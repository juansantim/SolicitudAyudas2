import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { UnavailableComponent } from './unavailable.component';

describe('UnavailableComponent', () => {
  let component: UnavailableComponent;
  let fixture: ComponentFixture<UnavailableComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ UnavailableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnavailableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
