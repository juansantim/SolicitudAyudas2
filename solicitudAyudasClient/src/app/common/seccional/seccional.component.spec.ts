import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { SeccionalComponent } from './seccional.component';

describe('SeccionalComponent', () => {
  let component: SeccionalComponent;
  let fixture: ComponentFixture<SeccionalComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ SeccionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeccionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
