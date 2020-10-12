import { BaseService } from './../../shared/base.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { ValidacaoForm } from 'src/app/shared/validacao-form.model';


export abstract class FrmBase<T> implements OnInit {

  public formBuilder: FormBuilder;
  public modelForm: FormGroup;
  public acaoAtual: string;
  route: ActivatedRoute;
  router: Router;
  modelBase: T;

  protected abstract construaModelForm();
  protected abstract cancelar();


  constructor(protected injector: Injector, protected service: BaseService<T>) {
    this.formBuilder = injector.get(FormBuilder);
    this.route = injector.get(ActivatedRoute);
    this.router = injector.get(Router);
  }
  ngOnInit(): void {
    this.construaModelForm();
    this.setAcaoAtual();
    this.carregarModel();
  }

  enviarForm() {

    if (this.modelForm.valid) {

      if (this.acaoAtual === 'novo') {
        this.criarModel();
      } else {
        this.editarModel();
      }

    } else {
      ValidacaoForm.MonteMensagemValidacao(this.modelForm);
    }
  }

  getObjeto(): T {
    const model: T = this.modelForm.value;
    return model;
  }

  editarModel() {
    const model: T = this.getObjeto();
    this.service.update(model)
                              .subscribe(
        m => this.acaoBemSucedida(model)
        , error => this.acaoErro(error)
      );
  }

  criarModel() {
    const model: T = this.getObjeto();

    this.service.create(model)
      .subscribe( m => this.acaoBemSucedida(m)
        , error => this.acaoErro(error));

  }

  carregarModel() {
    if (this.acaoAtual === 'atualizar') {

      this.route.paramMap.pipe(
        switchMap(params => this.service.getById(+params.get('id')))
      ).subscribe(m => {
        this.modelBase = m;
        this.carregueModelCustomEmEdicao();
      }, error => alert('Ocorreu um erro interno no servidor'));
    } else {
      this.carregueModelCustomEmCadastro();
    }
    }


  protected carregueModelCustomEmEdicao(): void {
    this.modelForm.patchValue(this.modelBase);
  }

  protected carregueModelCustomEmCadastro(): void { }



  setAcaoAtual() {
    if (this.route.snapshot.url[0].path === 'atualizar') {
      this.acaoAtual = 'atualizar';
    } else {
      this.acaoAtual = 'novo';
    }
  }

  private acaoBemSucedida(model: T) {

    alert('Solicitação processada com sucesso');

    this.acaoAtual = 'novo';
    // this.setPaginaTitulo();
    this.modelForm.reset();
    this.router.navigateByUrl('/' + this.router.url.split('/')[1]);
  }

  private acaoErro(erro) {
    if (erro.status == 422) {
      const msg = JSON.parse(erro._body).errors;
    } else {
     const msg = ['Falha na comunicação com o servidor. Por favor tente mais tarde.'];
    }
  }

  public controleValido(controle) {
    return ValidacaoForm.controleValido(controle);
  }
}
