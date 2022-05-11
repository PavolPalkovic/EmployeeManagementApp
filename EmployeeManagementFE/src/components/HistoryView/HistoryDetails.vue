<template>
    <div class="backdrop" @click.self="close">
        <div class="details">
            <button @click="close">X</button>
            <h4>First Name: {{ employee.firstName }}</h4>
            <h4>Last Name: {{ employee.lastName }}</h4>
            <h4>Address: {{ employee.address }}</h4>
            <h4>Date Of Birth: {{ employee.dateOfBirth }}</h4>
            <h4>Position: {{ employee.position.name }}</h4>
            <h4>Starting Date: {{ employee.startingDate }}</h4>
            <h4>Salary: {{ employee.salary }} €</h4>
        </div>
    </div>
</template>

<script>
export default {
    props: ['employee' ],
    methods: {
        // Custom event. Parent component listens to event named "closeDetails".
        // $emit('nameOfEvent')
        close() {
            this.$emit('closeDetails');
        }
    },
    mounted() {
      this.employee.startingDate = this.employee.startingDate.split("T")[0];
      this.employee.dateOfBirth = this.employee.dateOfBirth.split("T")[0]; 
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