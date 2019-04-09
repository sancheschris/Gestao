<template>
    <div class="admin-pages">
        <PageTitle icon="fa fa-cogs" main="Administração do Sistema"
            sub="Cadastros" />
            <div class="admin-pages-tabs">
                <b-card no-body>
                    <b-tabs card>
                        <b-tab title="Cursos" active>
                            <CursosAdmin />
                        </b-tab>
                        <b-tab title="Categorias" active>
                            <CategoryAdmin />
                        </b-tab>
                        <b-tab title="Usuários" active>
                            <UserAdmin />
                        </b-tab>
                    </b-tabs>  
                </b-card>
            </div>
    </div>
</template>

<script>
import PageTitle from '../template/PageTitle'
import CursosAdmin from './CursosAdmin'
import UserAdmin from './UserAdmin'
import CategoryAdmin from './CategoryAdmin'

export default {
    name: 'AdminPages',
    components: { PageTitle, CursosAdmin, UserAdmin, CategoryAdmin }
}
</script>

<style>

</style>
