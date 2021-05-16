import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { SelectedFilterComponent } from './selected-filter.component';

describe('SelectedFilterComponent', () => {
  let component: SelectedFilterComponent;
  let fixture: ComponentFixture<SelectedFilterComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectedFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectedFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
