<template>
    <div class="home">
        <PageTitle icon="fa fa-home" main="DashBoard"
            sub="Gestão de Aula" />
        <div class="stats">
            <Stat title="Cursos" :value="stat.cursos"
                icon="fa fa-folder"  color="#d54d50" />
            <Stat title="PlanoEnsino" :value="stat.planoEnsino"
                icon="fa fa-file" color="#3bc480" />
             <Stat title="Usuários" :value="stat.users"
                icon="fa fa-user" color="#3282cd" />
        </div>

    </div>
</template>

<script>
import PageTitle from '../template/PageTitle'
import Stat from './Stat'
import axios from 'axios'
//import { baseApiUrl } from '@/global'

export default {
    name: 'Home',
    components: { PageTitle, Stat },
    data: function() {
        return {
            stat: {}
        }
    },
    methods: {
       /* getStats() {
            axios.get('${baseApiUrl}/stats').then(res => this.stat = res.data)
        },
    },
    mounted() {
        this.getStats()
    }*/
    }
}
</script>

<style>
    .stat {
        display: flex;
        justify-content: space-between;
        flex-wrap: wrap;
    }
</style>
