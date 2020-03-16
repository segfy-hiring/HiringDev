<template>
	<div id="app" class="container">
	<h1>Pesquisar canal/video YouTube </h1>

	<b-card>
		<b-form-input type="text" size="lg"
		v-model="texto"
		placeholder="Texto para pesquisa"></b-form-input>
		<hr>
		<b-button @click="pesquisaTexto()" size="lg" variant="primary">Pesquisar</b-button>
	</b-card>

        <div>
            <div v-if="!videos && textoPesquisa" class="text-center">
                <p><em>Carregando vídeos...</em></p>
                <h1><icon icon="spinner" pulse/></h1>
            </div>


            <template v-if="videos">
				
				<h2>Lista de vídeos</h2>
                
				<table class="table">
                    <thead class="dark-bg text-white">
                        <tr>
                            <th>Imagem</th>
                            <th>Titulo</th>
                            <th>Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(video, index) in videos" :key="index">
							<td><img v-bind:src="video.urlImagem" /></td>
                            <td>{{ video.titulo }}</td>
                            <td>{{ video.descricao }}</td>
                        </tr>
                    </tbody>
                </table>
                <nav aria-label="...">
                    <ul class="pagination justify-content-center">
                        <li :class="'page-item' + (paginaAtualVideos == 1 ? ' disabled' : '')">
                            <a class="page-link" href="#" tabindex="-1" @click="pesquisarVideos(paginaAtualVideos - 1)">Anterior</a>
                        </li>
                        <li :class="'page-item' + (n == paginaAtualVideos ? ' active' : '')" v-for="(n, index) in totalPaginasVideos" :key="index">
                            <a class="page-link" href="#" @click="pesquisarVideos(n)">{{n}}</a>
                        </li>
                        <li :class="'page-item' + (paginaAtualVideos < totalPaginasVideos ? '' : ' disabled')">
                            <a class="page-link" href="#" @click="pesquisarVideos(paginaAtualVideos + 1)">Próximo</a>
                        </li>
                    </ul>
                </nav>
            </template>
        </div>

        <div>
            <div v-if="!canais && textoPesquisa" class="text-center">
                <p><em>Carregando canais...</em></p>
                <h1><icon icon="spinner" pulse/></h1>
            </div>

            <template v-if="canais">
				
				<h2>Lista de Canais</h2>
                
				<table class="table">
                    <thead class="dark-bg text-white">
                        <tr>
                            <th>Imagem</th>
                            <th>Titulo</th>
                            <th>Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(canal, index) in canais" :key="index">
                            <td><img v-bind:src="canal.urlImagem" /></td>
                            <td>{{ canal.titulo }}</td>
                            <td>{{ canal.descricao }}</td>
                        </tr>
                    </tbody>
                </table>
                <nav aria-label="...">
                    <ul class="pagination justify-content-center">
                        <li :class="'page-item' + (paginaAtualCanais == 1 ? ' disabled' : '')">
                            <a class="page-link" href="#" tabindex="-1" @click="pesquisarCanais(paginaAtualCanais - 1)">Anterior</a>
                        </li>
                        <li :class="'page-item' + (n == paginaAtualCanais ? ' active' : '')" v-for="(n, index) in totalPaginasCanais" :key="index">
                            <a class="page-link" href="#" @click="pesquisarCanais(n)">{{n}}</a>
                        </li>
                        <li :class="'page-item' + (paginaAtualCanais < totalPaginasCanais ? '' : ' disabled')">
                            <a class="page-link" href="#" @click="pesquisarCanais(totalPaginasCanais + 1)">Próximo</a>
                        </li>
                    </ul>
                </nav>
            </template>
        </div>
	</div>
</template>

<script>
export default {

  computed: {
    totalPaginasVideos: function () {
      return Math.ceil(this.totalVideos / this.quantidade)
    },
    totalPaginasCanais: function () {
      return Math.ceil(this.totalCanais / this.quantidade)
    }
  },

  data () {
    return {
	  texto: null, 
	  textoPesquisa: null,
      videos: null,
      canais: null,
      totalVideos: 0,
      totalCanais: 0,
      paginaAtualVideos: 1,
      paginaAtualCanais: 1,
      quantidade: 10
    }
  },

  methods: {
    async pesquisarVideos (pagina) {

      this.paginaAtualVideos = pagina

      try {
        let response = await this.$http.get(`/api/YouTube/PesquisarVideos?texto=${this.textoPesquisa}&pagina=${this.paginaAtualVideos}&quantidade=${this.quantidade}`)
		console.log(response.data.videos)
        this.videos = response.data.videos
        this.totalVideos = response.data.total
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    },

  async pesquisarCanais (pagina) {

      this.paginaAtualCanais = pagina

      try {
        let response = await this.$http.get(`/api/YouTube/PesquisarCanais?texto=${this.textoPesquisa}&pagina=${this.paginaAtualCanais}&quantidade=${this.quantidade}`)
        console.log(response.data.canais)
        this.canais = response.data.canais
        this.totalCanais = response.data.total
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
	},
	
	async pesquisaTexto () {

        this.videos = null
        this.canais = null

		this.textoPesquisa = this.texto
        this.pesquisarVideos(1)
        this.pesquisarCanais(1)
	}
  },  
}
</script>

<style>
#app {
	font-family: 'Avenir', Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	color: #2c3e50;
	font-size: 1.5rem;
}

#app h1 {
	text-align: center;
	margin: 50px;
}
</style>
