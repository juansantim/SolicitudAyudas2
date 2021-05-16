import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ProcesarSolicitudComponent } from './procesar-solicitud.component';

describe('ProcesarSolicitudComponent', () => {
  let component: ProcesarSolicitudComponent;
  let fixture: ComponentFixture<ProcesarSolicitudComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcesarSolicitudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcesarSolicitudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
