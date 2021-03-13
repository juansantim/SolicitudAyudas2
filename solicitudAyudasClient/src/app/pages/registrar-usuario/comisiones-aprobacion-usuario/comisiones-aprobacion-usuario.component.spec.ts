import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComisionesAprobacionUsuarioComponent } from './comisiones-aprobacion-usuario.component';

describe('ComisionesAprobacionUsuarioComponent', () => {
  let component: ComisionesAprobacionUsuarioComponent;
  let fixture: ComponentFixture<ComisionesAprobacionUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComisionesAprobacionUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComisionesAprobacionUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
