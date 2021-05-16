import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EstadoSolicitudComponent } from './estado-solicitud.component';

describe('EstadoSolicitudComponent', () => {
  let component: EstadoSolicitudComponent;
  let fixture: ComponentFixture<EstadoSolicitudComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EstadoSolicitudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstadoSolicitudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
