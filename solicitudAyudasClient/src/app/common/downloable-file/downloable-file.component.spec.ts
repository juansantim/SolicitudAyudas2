import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DownloableFileComponent } from './downloable-file.component';

describe('DownloableFileComponent', () => {
  let component: DownloableFileComponent;
  let fixture: ComponentFixture<DownloableFileComponent>;

  beforeEach(async(() => {
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
