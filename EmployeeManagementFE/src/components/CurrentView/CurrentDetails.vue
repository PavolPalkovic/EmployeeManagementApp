<template>
    <div class="backdrop" @click.self="close">
        <div class="details">
            <button @click="close">X</button>
            <h4>First Name: {{ firstName }}</h4>
            <h4>Last Name: {{ lastName }}</h4>
            <h4>Address: {{ address }}</h4>
            <h4>Date Of Birth: {{ dateOfBirth }}</h4>
            <h4>Position: {{ position.name }}</h4>
            <h4>Starting Date: {{ startingDate }}</h4>
            <h4>Salary: {{ salary }} €</h4>
        </div>
    </div>
</template>

<script>
export default {
    props: ['firstName', 'lastName', 'address', 'dateOfBirth', 'position', 'startingDate', 'salary'],
    methods: {
        // Custom event. Parent component listens to event named "closeDetails".
        // $emit('nameOfEvent')
        close() {
            this.$emit('closeDetails');
        }
    }
}
</script>


<style scoped>
    .details {
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