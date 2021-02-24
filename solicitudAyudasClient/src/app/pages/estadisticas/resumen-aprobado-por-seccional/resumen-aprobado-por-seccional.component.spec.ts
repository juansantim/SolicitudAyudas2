import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResumenAprobadoPorSeccionalComponent } from './resumen-aprobado-por-seccional.component';

describe('ResumenAprobadoPorSeccionalComponent', () => {
  let component: ResumenAprobadoPorSeccionalComponent;
  let fixture: ComponentFixture<ResumenAprobadoPorSeccionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResumenAprobadoPorSeccionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResumenAprobadoPorSeccionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
