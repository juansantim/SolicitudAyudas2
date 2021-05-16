import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PermisosUsuarioComponent } from './permisos-usuario.component';

describe('PermisosUsuarioComponent', () => {
  let component: PermisosUsuarioComponent;
  let fixture: ComponentFixture<PermisosUsuarioComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PermisosUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PermisosUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
