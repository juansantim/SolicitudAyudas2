import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ComisionesAprobacionUsuarioComponent } from './comisiones-aprobacion-usuario.component';

describe('ComisionesAprobacionUsuarioComponent', () => {
  let component: ComisionesAprobacionUsuarioComponent;
  let fixture: ComponentFixture<ComisionesAprobacionUsuarioComponent>;

  beforeEach(waitForAsync(() => {
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
