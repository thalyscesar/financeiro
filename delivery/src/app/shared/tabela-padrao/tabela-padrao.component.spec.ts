import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TabelaPadraoComponent } from './tabela-padrao.component';

describe('TabelaPadraoComponent', () => {
  let component: TabelaPadraoComponent;
  let fixture: ComponentFixture<TabelaPadraoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TabelaPadraoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TabelaPadraoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
