var Notificador = /** @class */ (function () {
    function Notificador() {
    }
    Notificador.prototype.enviar = function () {
        console.log('Enviando notifica��o>>');
    };
    return Notificador;
}());
var Post = /** @class */ (function () {
    function Post(titulo, notificador) {
        this.titulo = titulo;
        this.notificador = notificador;
        console.log('Novo Post: ' + titulo);
    }
    Post.prototype.publicar = function () {
        console.log('--> Publicando!');
        this.notificador.enviar();
    };
    return Post;
}());
var novoPost = new Post('Injecao de dependencia:', new Notificador());
novoPost.publicar();
