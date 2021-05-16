import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ResumenSolicitadoPorSucursalComponent } from './resumen-solicitado-por-sucursal.component';

describe('ResumenSolicitadoPorSucursalComponent', () => {
  let component: ResumenSolicitadoPorSucursalComponent;
  let fixture: ComponentFixture<ResumenSolicitadoPorSucursalComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ResumenSolicitadoPorSucursalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResumenSolicitadoPorSucursalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
