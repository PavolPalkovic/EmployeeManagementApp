<template>
  <div>
    <div v-if="componentName == 'componentCreate'">
      <PositionCreate @closeCreate="componentName = ''"
      :getPositionsParent="this.getPositions"/>
    </div>
    <div v-if="componentName == 'componentDelete'">
      <PositionDelete @closeDelete="componentName = ''"
      :id="this.positionId"
      :name="this.positionName"
      :description="this.positionDescription"
      :getPositionsParent="this.getPositions"/>
    </div>
    <h1>Positions</h1>
    <button @click="showCreateComponent('componentCreate')">Create</button>
    <div v-for="position in positions" :key="position.id">
      <h4>{{ position.name }}</h4>
      <p>{{ position.description }}</p>
      <button @click="showComponent(position, 'componentDelete')">Delete</button>
    </div>
  </div>
</template>

<script>
import PositionCreate from '../components/PositionView/PositionCreate.vue'
import PositionDelete from '../components/PositionView/PositionDelete.vue'

export default {
  name: 'PositionsView',
  components: {
    PositionCreate, PositionDelete
  },
  data() {
    return {
      positions: [
        // { id: "1", name: "cook", description: "cooking" },
        // { id: "2", name: "aaa", description: "dasd dasdv fgdfgt" },
        // { id: "3", name: "bbb", description: "opopo it ew" }
      ],
      positionId: 0,
      positionName: "",
      positionDescription: "",
      componentName: ""
    }
  },
  mounted() {
    this.getPositions()
  },
  methods: {
    getPositions() {
      fetch('http://localhost:1028/api/positions')
        .then(response => response.json())
        .then(data => {this.positions = data})
    },
    passValues(pos) {
      this.positionId = pos.id;
      this.positionName = pos.name;
      this.positionDescription = pos.description;
    },
    showComponent(pos, componentName) {
      this.passValues(pos);
      this.componentName = componentName;
    },
    showCreateComponent(componentName) {
      this.componentName = componentName;
    }
  }
}
</script>