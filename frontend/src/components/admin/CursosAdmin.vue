<template>
    <div class="curso-admin">
        <b-form>
            <input id="curso-id" type="hidden" v-model="curso.cursoId" />
            <b-row>
                <b-col md="6" sm="12">
                    <b-form-group label="Nome:" label-for="curso-name">
                        <b-form-input id="curso-name" type="text"
                            v-model="curso.nome" required
                            :readonly="mode === 'remove'"
                            placeholder="Informe o Nome do Curso..." />
                    </b-form-group>
                </b-col>
            </b-row>
            <input id="curso-id" type="hidden" v-model="curso.coordenadorId" />
                <b-form-group label="Coordenador:" label-for="curso-coordenadorId">
                    <b-form-input  id="curso-name" type="text" 
                    v-model="curso.coordenadorId" required
                        :readonly="mode === 'remove'"
                        placeholder="Informe o Nome do Coordenador..."/>
                </b-form-group>
            <b-col xs="12">  
                <b-button variant="primary" v-if="mode === 'save'"
                    @click="save">Salvar</b-button>
                <b-button variant="danger" v-if="mode === 'remove'"
                    @click="remove">Excluir</b-button>
                <b-button class="ml-2" @click="reset">Cancelar</b-button>
            </b-col>
        </b-form>
        <hr>
        <b-table hover striped :items="cursos" :fields="fields">
            <template slot="actions" slot-scope="data">
                <b-button variant="warning" @click="loadCurso(data.item)" class="mr-2">
                    <i class="fa fa-pencil"></i>
                </b-button>
                <b-button variant="danger" @click="loadCurso(data.item, 'remove')">
                    <i class="fa fa-trash"></i>
                </b-button>
            </template>
        </b-table>
    </div>
</template>

<script>
import  { baseURL, showError }  from '@/global'

import axios from 'axios'

export default {

    name: 'CursosAdmin',
    data: function() {
        return {
            mode: 'save',
            curso: {},
            cursos: [],
            fields: [
                { key: 'cursoId', label: 'Código', sortable: true },
                { key: 'nome', label: 'Nome', sortable: true },
                { key: 'coodernadorId', label: 'Coodernador', sortable: true },
                { key: 'actions', label: 'Ações' }
            ]
        }
    },
    methods: {
        loadCursos() {
            const url = `${baseURL}/cursos`
            axios.get(url).then(res => {
                this.cursos = res.data
                console.log(this.cursos)
          })
        },
        reset() {
            this.mode = 'save'
            this.curso = {}
            this.loadCursos()
        },
        save() {
            const method = this.curso.cursoId ? 'put' : 'post'
            const cursoId = this.curso.cursoId ? `/${this.curso.cursoId}` : ''
            axios[method](`${baseURL}/cursos${cursoId}`, this.curso)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        remove() {
            const id = this.curso.cursoId
            axios.delete(`${baseURL}/cursos/${id}`)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        loadCursos(cursos, mode = 'save') {
            this.mode = mode
            this.curso = {...curso }
        }
    },
    mounted() {
        this.loadCursos()
    }
}
</script>

<style>

</style>

