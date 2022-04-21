<template>
    <div class="backdrop" @click.self="closeDelete">
        <div class="delete">
            <h4>Do you really want to delete employee: {{ firstName }} {{ lastName }}</h4>
            <button @click="deleteHistoryEmployee(); closeDelete(); reloadPage();">Yes</button>
            <button @click="closeDelete">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: [ 'id', 'firstName', 'lastName' ],
    methods: {
        closeDelete() {
            this.$emit('closeDelete');
        },
        deleteHistoryEmployee() {
            axios.delete('http://localhost:1028/api/employeesHistory/' + this.id)
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
    .delete {
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