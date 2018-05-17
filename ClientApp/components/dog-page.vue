<template>
    <v-card class="white--text">
        <v-card-title>
            <div class="headline">Dogs ({{pagination.totalItems}} )</div>
            <v-btn fab dark small color="indigo" @click="addDog">
                <v-icon dark>add</v-icon>
            </v-btn>
            <v-spacer></v-spacer>
            <v-text-field v-model="search"
                          append-icon="search"
                          label="Search"
                          single-line
                          hide-details></v-text-field>
        </v-card-title>
        <v-data-table v-model="selected"
                      :headers="headers"
                      :items="dogs"
                      :loading="loading"
                      :search="search"
                      :pagination.sync="pagination"
                      select-all
                      item-key="name"
                      class="elevation-1"
                      light>
            <template slot="headers" slot-scope="props">
                <tr>
                    <th v-for="header in props.headers"
                        :key="header.text"
                        :class="['column sortable', pagination.descending ? 'desc' : 'asc', header.value === pagination.sortBy ? 'active' : '']"
                        @click="changeSort(header.value)">
                        <v-icon small>arrow_upward</v-icon>
                        {{ header.text }}
                    </th>
                    <th>
                        Actions
                    </th>
                </tr>
            </template>
            <template slot="items" slot-scope="props">
                <tr :active="props.selected" @click="props.selected = !props.selected">
                    <td>{{ props.item.name }}</td>
                    <td class="justify-center layout px-0">
                        <v-btn icon class="mx-0" @click="editItem(props.item)">
                            <v-icon color="teal">edit</v-icon>
                        </v-btn>
                        <v-btn icon class="mx-0" @click="deleteItem(props.item)">
                            <v-icon color="pink">delete</v-icon>
                        </v-btn>
                    </td>
                </tr>
            </template>
            <template slot="no-data">
                No data
            </template>
        </v-data-table>
        <dog-dialog :add="add" :dialog="dialog" :data="selectedDog" @onConfirm="save" @onCancel="dialog = false"></dog-dialog>
        <v-dialog v-model="deleteDialog" persistent max-width="500px">
            <v-card>
                <v-card-title>
                    Are you sure you want to delete dog breed:  {{selectedDog.name}} ?
                </v-card-title>
                <v-card-actions>
                    <v-btn color="primary" flat @click.native="deleteDialog = false">Close</v-btn>
                    <v-btn color="blue darken-1" flat @click="deleteDog()">Confirm</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-card>
</template>
<script>
    import Vue from 'vue'
    import dogDialog from './dog-dialog.vue'
    import { mapGetters } from 'vuex'
    Vue.component('dog-dialog', dogDialog)
    export default {
        computed: {
            ...mapGetters({
                dogs: 'getDogs'
            })
        },
        data: () => ({
            pagination: {
                sortBy: 'name'
            },
            selectedDog: {},
            selected: [],
            deleteDialog: false,
            add:false,
            dialog: false,
            loading: false,
            search: '',
            headers: [
                {
                    text: 'Dog Breed',
                    align: 'left',
                    value: 'name'
                }
            ]
        }),

        methods: {
            changeSort(column) {
                if (this.pagination.sortBy === column) {
                    this.pagination.descending = !this.pagination.descending
                } else {
                    this.pagination.sortBy = column
                    this.pagination.descending = false
                }
            },
            addDog() {
                this.selectedDog = Object.assign({}, {})
                this.add = true
                this.dialog = true
            },
            getData() {
                this.$store.dispatch('getDogs')
            },
            editItem(dog) {
                this.selectedDog = Object.assign({}, dog)
                this.add = false
                this.dialog = true
                
            },
            deleteItem(dog) {
                this.selectedDog = Object.assign({}, dog)
                this.deleteDialog = true
            },
            save() {
                if (this.add){
                    this.$store.dispatch('saveDog', this.selectedDog).then(() => {
                        this.dialog = false
                    })
                } else {
                    this.$store.dispatch('updateDog', this.selectedDog).then(() => {
                        this.dialog = false
                    })
                }
            },
            deleteDog() {
                this.$store.dispatch('deleteDog', this.selectedDog).then(() => {
                    this.deleteDialog = false
                })
            }
        },

        mounted () {
            this.getData()
        }
    }
</script>
