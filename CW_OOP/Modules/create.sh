declare -a arr=(
# "Automechanic"
"DocumentType"
# "Driver"
"FuelMeasurementHistory"
# "FuelType"
"MaintenanceHistory"
# "MaintenanceType"
# "Manufacturer"
"MileageMeasurementHistory"
# "OilType"
"PlannedMaintenanceSchedule"
"RefuelingHistory"
"RepairConsumedSparePart"
"RepairHistory"
# "SparePart"
# "User"
"Vehicle"
# "VehicleCategory"
"VehicleDocument"
"VehicleModel"
"VehiclePhoto"
# "VehicleStatus"
)
for i in "${arr[@]}"
do
    mkdir -p $i
    cp -R Role/* $i
    rm ./$i/Role.cs
    rm ./$i/RoleMap.cs
    find . -type f -wholename "./$i/**/*.cs" -exec sed -i.bak "s/Role/$i/g" {} \;
    rm ./$i/**/*.bak
done
