import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { DownloableFileComponent } from './downloable-file.component';

describe('DownloableFileComponent', () => {
  let component: DownloableFileComponent;
  let fixture: ComponentFixture<DownloableFileComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ DownloableFileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DownloableFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
