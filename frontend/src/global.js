import Vue from 'vue'

export const baseURL = 'https://localhost:44373/api'
export const userKey = '_USER'



export function showError(e) {
    if(e && e.response && e.response.data) {
        Vue.toasted.global.defaultError({ msg : e.response.data })
    } else if(typeof e === 'string') {
        Vue.toasted.global.defaultError({ msg : e })
    } else {
        Vue.toasted.global.defaultError()
    }
}

export default { baseURL, showError, userKey }

