import { http } from './global'

export default {

    listar:() => {
        //return http.get('produtos')
        return http.get('usuarios')
    },
    
    salvar:(usuario) => {
        return http.post('usuarios', usuario)
    },

    atualizar:(usuario) => {
        return http.put('usuarios', usuario)
    }
}