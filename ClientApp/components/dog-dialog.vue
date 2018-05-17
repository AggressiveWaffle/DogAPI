<template>
    <v-dialog v-model="dialog" persistent>
        <v-card>
            <v-card-title v-if="add">
                Create Dog
            </v-card-title>
            <v-card-title v-if="!add">
                Update Dog
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-form>
                        <v-layout wrap>
                            <v-flex xs12>
                                <v-text-field v-validate="'required'"
                                              v-model="data.name"
                                              label="Dog Breed"
                                              :error-messages="errors.collect('name')"
                                              data-vv-name="name" required>
                                </v-text-field>
                            </v-flex>
                        </v-layout>
                    </v-form>
                </v-container>
                <small>*indicates required field</small>
            </v-card-text>
            <v-card-actions>
                <v-btn color="primary" flat @click.native="$emit('onCancel')">Close</v-btn>
                <v-btn color="blue darken-1" flat @click="save()">Save</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>
<script>

export default {
        props: ['dialog', 'data', 'add'],
        methods: {
            save: function () {
                let scope = this
                this.$validator.validateAll().then(function (res) {
                    if (res) { scope.$emit('onConfirm') }
                })
            }
        }
}
</script>
<style>

</style>
