<template>
    <div class="backdrop" @click.self="closeCreate">
        <div class="create">
            <h4>*Name: <input type="text" v-model="positionData.name"> </h4>
            <h4>Description: <input type="text" v-model="positionData.description"> </h4>
            <button @click="createPosition(); closeCreate(); reloadPage();" :disabled="!positionData.name">Create</button>
            <button @click="closeCreate">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: [ ],
    data() {
        return {
            positionData: {
                name: '',
                description: ''
            }
        }
    },
    methods: {
        closeCreate() {
            this.$emit('closeCreate');
        },
        createPosition() {
            axios.post('http://localhost:1028/api/positions', this.positionData)
                .then(response => console.log(response))
                .catch(error => console.log(error))
        },
        reloadPage() {
            window.location.reload();
        }
    }
}
</script>


<style scoped>
    .create {
        width: 400px;
        padding: 20px;
        margin: 100px auto;
        background: white;
        border-radius: 10px;
    }
    .backdrop {
        top: 0;
        position: fixed;
        background: rgba(0,0,0,0.5);
        width: 100%;
        height: 100%;
    }
</style>