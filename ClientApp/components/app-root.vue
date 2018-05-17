<template>
    <v-app id="app" dark>
        <v-toolbar app fixed clipped-left>
            <v-toolbar-title>Dog register</v-toolbar-title>
        </v-toolbar>
        <v-content>
            <v-container fluid>
                <router-view></router-view>
            </v-container>
        </v-content>
        <v-footer app></v-footer>
    </v-app>

</template>

<script>
import Vue from 'vue'


export default {
    data() {
        return {
        }
    }
}
</script>

<style>
</style>
