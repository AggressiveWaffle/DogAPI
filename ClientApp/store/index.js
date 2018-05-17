import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios' 
Vue.use(Vuex)

// TYPES
const DOGS = 'DOGS'

// STATE
const state = {
    dogs: []
}

// MUTATIONS
const mutations = {
    [DOGS](state, obj) {
        state.dogs = obj
    }
}

// ACTIONS
const actions = ({
    //Will call api/dogs and set state
    getDogs({ commit }, obj) {
        axios.get('api/dogs')
            .then(function (response) {
                commit(DOGS, response.data)
            })
            .catch(function (error) {
                //Log error's better in production
                console.log(error);
            });
        
    },
    //Adds a new dog and then updates list
    saveDog({ dispatch }, obj) {
        axios.post('api/dogs',obj)
            .then(function (response) {
                dispatch('getDogs')
            })
            .catch(function (error) {
                //Log error's better in production
                console.log(error);
            });

    },
    //Updates a dog and then updates list
    updateDog({ dispatch }, obj) {
        axios.put('api/dogs/'+obj.id, obj)
            .then(function (response) {
                dispatch('getDogs')
            })
            .catch(function (error) {
                //Log error's better in production
                console.log(error);
            });

    },
    //Updates a dog and then updates list
    deleteDog({ dispatch }, obj) {
        axios.delete('api/dogs/' + obj.id)
            .then(function (response) {
                dispatch('getDogs')
            })
            .catch(function (error) {
                //Log error's better in production
                console.log(error);
            });

    }
})

// getters
const getters = {
    getDogs: state => state.dogs
}

export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters
});
