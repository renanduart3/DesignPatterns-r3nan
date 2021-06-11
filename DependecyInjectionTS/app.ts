class Notificador {

    enviar() {
        console.log('Enviando notifica��o>>');
    }
}
interface INotificador {
    enviar();
}
class Post {

    constructor(public titulo: string, private notificador: INotificador) {
        console.log('Novo Post: ' + titulo);
    }

    publicar() {
        console.log('--> Publicando!');
        this.notificador.enviar();
    }
}

let novoPost = new Post('Injecao de dependencia:', new Notificador());
novoPost.publicar();
