import {  FormGroup, FormControl } from '@angular/forms';
import * as toastr from 'toastr';
import * as $ from 'jquery';

export class ValidacaoForm {

   public static controleValido(controle) {

        if (controle.invalid && (controle.touched || controle.dirty)){
          return {'is-invalid': true } ;
        }
        else if (controle.valid && (controle.touched || controle.dirty)){
          return {'is-valid': true };
        }
      }

    // public static ManipuleValidacao(group: FormGroup) {

    //     Object.keys(group.controls).forEach(key => {
    //       group.controls[key].markAsPristine
    //       group.controls[key].markAsUntouched
    //     });
    //     group.reset();
    // }

    public static MonteMensagemValidacao(group: FormGroup) {

      Object.keys(group.controls).forEach(key => {

        group.controls[key].markAsDirty;
        group.controls[key].markAsTouched;
      });

      Object.keys(group.controls).forEach(key => {

        if (group.controls[key].invalid) {
          const msg = this.getMensagem(group.controls[key], key);
          if (msg) {
            toastr.info(msg);
          }
        }
      });

    }

    public static getMensagem(formControl: any, key: any ): string {

      if (this.mostrarMensagem(formControl)) {
        return this.obtenhaMsgDeErro(formControl, key);
      } else {
        return null;
      }
    }

    private static mostrarMensagem(formControl: FormControl): boolean {
      return formControl.invalid;
    }

    private static obtenhaMsgDeErro(formControl: FormControl, key: string): string {

     const nomeElemento = !$("label[for=" + key + "]")[0] ? key : $("label[for=" + key + "]")[0].innerText;

     if (formControl.errors.required) {
        return nomeElemento + ' é obrigatorio';
      }

      else if (formControl.errors.email) {
        return 'formato de email inválido'
           }

      else if (formControl.errors.minlength) {
        const requiredLength = formControl.errors.minlength.requiredLength;
        return `${nomeElemento} deve ter no mínimo ${requiredLength} caracteres`;
      }

      else if (formControl.errors.maxlength) {
        const requiredLength = formControl.errors.maxlength.requiredLength;
        return `${nomeElemento} deve ter no máximo ${requiredLength} caracteres`;
      }

      else if (formControl.errors.min) {
        const requiredMin = formControl.errors.min.actual;
        // tslint:disable-next-line: radix
        return `${nomeElemento} deve ser maior que ${parseInt(requiredMin)}`;
      }

    }
}
