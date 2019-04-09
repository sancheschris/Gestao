<template>
    <div class="user-admin">
        <b-form>
            <input type="hidden" id="user-id" v-model="user.usuarioId" />
            <b-row>
                <b-col md="6" sm="12">
                    <b-form-group label="Nome:" label-for="user-name">
                        <b-form-input id="user-name" type="text"
                            v-model="user.nome" required 
                            :readonly="mode === 'remove'"
                            placeholder="Informe o Nome do Usuário..."/>
                    </b-form-group>
                </b-col>
                    <b-col md="6" sm="12">
                        <b-form-group label="E-mail:" label-for="user-email">
                        <b-form-input id="user-email" type="text"
                            v-model="user.email" required 
                            placeholder="Informe o E-mail do Usuário..."/>
                        </b-form-group>
                </b-col>
            </b-row>
            <b-form-checkbox id="user-admin" v-model="user.privilegio" class="mt-3 mb-3" >
                Administrador?
            </b-form-checkbox>      
            <b-row v-show="mode === 'save'">
                <b-col md="6" sm="12">
                    <b-form-group label="Senha:" label-for="user-password">
                        <b-form-input id="user-password" type="password"
                            v-model="user.senha" required 
                            placeholder="Informe a Senha do Usuário..."/>
                    </b-form-group>
                </b-col>
                    <b-col md="6" sm="12">
                        <b-form-group label="Confirmação de Senha:" label-for="user-confir-password">
                        <b-form-input id="user-confirm-password" type="password"
                            v-model="user.senha" required 
                            placeholder="Confirme a senha do Usuário..."/>
                        </b-form-group>
                </b-col>
            </b-row>
            <b-button variant="primary" v-if="mode === 'save'"
                @click="save">Salvar</b-button>
            <b-button variant="danger" v-if="mode === 'remove'"
                @click="remove">Excluir</b-button>
            <b-button class="ml-2" @click="reset">Cancelar</b-button>
        </b-form>
        <hr>
        <b-table hover striped :items="users" :fields="fields">
            <template slot="actions" slot-scope="data">
                <b-button variant="warning" @click="loadUser(data.item)" class="mr-2">
                    <i class="fa fa-pencil"></i>
                </b-button>
                <b-button variant="danger" @click="loadUser(data.item, 'remove')">
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

    name: "UserAdmin",
    data: function() {
        return {
            mode: 'save',
            user: {},
            users: [],
            fields: [
                { key: 'usuarioId', label: 'Código', sortable: true },
                { key: 'nome', label: 'Nome', sortable: true },
                { key: 'email', label: 'E-mail', sortable: true },
                { key: 'privilegio', label: 'Administrador', sortable: true,
                    formatter: value => value ? 'Sim' : 'Não' },
                { key: 'actions', label: 'Ações' }
            ]
        }
    },
    methods: {
        loadUsers() {
            const url = `${baseURL}/usuarios`
            axios.get(url).then(res => {
                this.users = res.data
                console.log(this.users)
          })
        },
        reset() {
            this.mode = 'save'
            this.user = {}
            this.loadUsers()
        },
        save() {
            const method = this.user.usuarioId ? 'put' : 'post'
            const usuarioId = this.user.usuarioId ? `/${this.user.usuarioId}` : ''
            axios[method](`${baseURL}/usuarios${usuarioId}`, this.user)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        remove() {
            const usuarioId = this.user.usaurioId
            axios.delete(`${baseURL}/usuarios/${usuarioId}`)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        loadUser(user, mode = 'save') {
            this.mode = mode
            this.user = {...user }
        }
    },
    mounted() {
        this.loadUsers()
    }
}
</script>

<style>

</style>
