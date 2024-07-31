using Assets.Script.Tasksystem;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using XNode;

public class TalkManger : MonoBehaviour
{
    [Header("对话资源")]
    public XNodeGraph NodeData; 
    public TaskData_So TaskData_So;
    public DelegateTaskable delegateTaskable;
    [Header("当前数据")]
    public BaseNode nextNode;
    public DialogueNode startNode;
    public DialogueNode currentNode;
    public SelectNode currentSelectNode;
    public DelegateTask currentDelegateTask;
    public EndTaskDiscribeNode currentEndTaskDiscribeNode;
    public TextMeshProUGUI content;
    public TextMeshProUGUI  _name;
    [Header("Button位置")]
    public GameObject a;
    public GameObject b;
    public GameObject c;
    [Header("Button的引用")]
    public Button aButton;
    public Button bButton;
    public Button cButton;
    [Header("文本索引")]
    public int idex=0;

   
    public bool canDelegateTask;
    private void Start()
    {
        //
        a = GameObject.Find("a");
        b = GameObject.Find("b");
        c = GameObject.Find("c");
        //
        delegateTaskable = GetComponent<DelegateTaskable>();
        TaskData_So = Resources.Load<TaskData_So>("So/TaskData_So");
        if(delegateTaskable != null)
        {
            canDelegateTask = true;
        }
        for (int i=0;i<NodeData.nodes.Count;i++)
        {
           
            BaseNode node = NodeData.nodes[i] as BaseNode;
            if (node.id == NodeData.CurrentID)
            {
                nextNode = node;
            }
        }
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) { 
            NextNode();
        }
    }
    public  void NextNode()
    {
        if (nextNode == null) { Debug.Log("结束"); return; }

        switch(nextNode.nodeType)
        {
          case NodeType.DialogueNode:

                Next_is_DialogueNode();
                idex++;
                if(idex >= currentNode.content.Count) {
                   if(nextNode.GetPort(fieldName: "exit").Connection== null)
                   {
                       nextNode = null;
                       return;
                   }
                    nextNode = nextNode.GetPort(fieldName: "exit").Connection.node as BaseNode;
                    NodeData.CurrentID = nextNode.id;
                    idex = 0;
                }
                return;
          case NodeType.EndTaskDiscribe:
              Next_is_ETDNode();
                idex++;
                if (idex >= currentEndTaskDiscribeNode.content.Count)
                {
                   
                    if (nextNode.GetPort(fieldName: "exit").Connection == null)
                    {
                        nextNode = null;
                        return;
                    }
                    BaseNode _node = nextNode.GetPort(fieldName: "exit").Connection.node as BaseNode;
                    nextNode = nextNode.GetPort(fieldName: "exit").Connection.node as BaseNode;
                    NodeData.CurrentID = nextNode.id;
                    idex = 0;
                    if (_node.nodeType == NodeType.Task)
                    {
                        DelegateTask dtask = _node as DelegateTask;
                        if (currentEndTaskDiscribeNode.taskid == dtask.Tasksid)
                        {
                           nextNode=null;
                        }
                    }

                }

                return;
               
         case  NodeType.Select:
                Next_is_SelectNode();
                return;
            case NodeType.Task:
                Next_is_TaskNode();
                return;

        }
       
    }
    public void Next_is_DialogueNode()
    {
        currentNode = nextNode as DialogueNode;
        ShowNode();
    }
    public void Next_is_SelectNode() {
         currentSelectNode = nextNode as SelectNode;
         ShowSelectNode();
    }
    public void Next_is_TaskNode()
    {
        currentDelegateTask = nextNode as DelegateTask;
        TaskDetails details = TaskData_So.TaskDetailsList.Find(i => i.id == currentDelegateTask.Tasksid);
        currentDelegateTask.taskStatus = details.status; 
        switch (details.status){
            case TotalStatus.Waitting:
                  TaskManage.Instance.DelegateTask(currentDelegateTask.Tasksid, delegateTaskable.delegateTaskList);
                  if (nextNode.GetPort("waittingexit").Connection== null)
                  {
                    nextNode = null;
                    return;
                  }
                  nextNode= nextNode.GetPort("waittingexit").Connection.node as BaseNode;
                  NodeData.CurrentID= nextNode.id;
                NextNode();
                return;
            case TotalStatus.Acccepted:
                if (nextNode.GetPort("acceptedexit").Connection == null)
                {
                    nextNode = null;
                    return;
                }
                nextNode = nextNode.GetPort("acceptedexit").Connection.node as BaseNode;
                NodeData.CurrentID = nextNode.id;
                NextNode();
                return;
            case TotalStatus.Completed:
                if (nextNode.GetPort("completedexit").Connection == null)
                {
                    nextNode = null;
                    return;
                }
                nextNode = nextNode.GetPort("completedexit").Connection.node as BaseNode;
                NodeData.CurrentID = nextNode.id;
                NextNode();
                return;
            case TotalStatus.Failed:
                if (nextNode.GetPort("failedexit").Connection == null)
                {
                    nextNode = null;
                    return;
                }
                nextNode = nextNode.GetPort("failedexit").Connection.node as BaseNode;
                NodeData.CurrentID = nextNode.id;
                NextNode();
                return;

        }
        

        
    }
    public void Next_is_ETDNode()
    {
        currentEndTaskDiscribeNode = nextNode as EndTaskDiscribeNode;
        ShowETDN();
    }
    public void ShowNode()
    {
        _name.text = currentNode._name;
        content.text = currentNode.content[idex];
    }
    public void ShowETDN()
    {
        _name.text = currentEndTaskDiscribeNode._name;
        content.text = currentEndTaskDiscribeNode.content[idex];

    }
    private bool is_a_Instance;
    private bool is_b_Instance;
    private bool is_c_Instance;
    private List<GameObject> ButtonList = new List<GameObject>();//方便销毁Button
    public void ShowSelectNode()
    {
        GameObject father = GameObject.Find("TalkScene");
        
        if (currentSelectNode.GetPort("a_exit").Connection != null)
        {
            if (!is_a_Instance)
            {
              Vector3 position =  a.transform.position;
            
              GameObject Button = GameObject.Instantiate(Resources.Load("Scene/Button"),position,Quaternion.identity,father.transform) as GameObject;
                ButtonList.Add(Button);
                aButton =Button.GetComponent<Button>();
                aButton.onClick.AddListener(A_Button_Next);
              TextMeshProUGUI buttonText = Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
              buttonText.text = currentSelectNode.a_selectDiscribe;
                is_a_Instance = true;
            }
        }
        if (currentSelectNode.GetPort("b_exit").Connection != null)
        {
            if (!is_b_Instance)
            {
            //
            Vector3 position = b.transform.position;
            //
            GameObject Button = GameObject.Instantiate(Resources.Load("Scene/Button"), position, Quaternion.identity, father.transform) as GameObject;
                ButtonList.Add(Button);
                bButton = Button.GetComponent<Button>();
                bButton.onClick.AddListener(B_Button_Next);
                TextMeshProUGUI buttonText = Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            buttonText.text = currentSelectNode.b_selectDiscribe;
                is_b_Instance = true;
            }
        }
        if (currentSelectNode.GetPort("c_exit").Connection != null)
        {
            if (!is_c_Instance)
            {
             //
            Vector3 position = c.transform.position;
            //
            GameObject Button = GameObject.Instantiate(Resources.Load("Scene/Button"), position, Quaternion.identity, father.transform) as GameObject;
                ButtonList.Add(Button);
                cButton = Button.GetComponent<Button>();
                cButton.onClick.AddListener(C_Button_Next);
                TextMeshProUGUI buttonText = Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            buttonText.text = currentSelectNode.c_selectDiscribe;
                is_c_Instance = true;
            }
        }
        if(!is_c_Instance&&!is_a_Instance&&!is_b_Instance)
        {
            nextNode = null;
            return;
        }
        _name.text = currentSelectNode._name;
    } 
     public  void A_Button_Next()
    {
        if(nextNode.GetPort(fieldName:("a_exit")).Connection == null) 
        {
            Debug.Log("结束");
            nextNode = null;
            return;
        }
        nextNode = nextNode.GetPort(fieldName: ("a_exit")).Connection.node as BaseNode;
        NodeData.CurrentID = nextNode.id;
        DestoryButton();
        NextNode();
    }
    public void B_Button_Next()
    {
        if (nextNode.GetPort(fieldName: ("b_exit")).Connection == null)
        {
            nextNode = null;
            return;
        }
        nextNode = nextNode.GetPort(fieldName: ("b_exit")).Connection.node as BaseNode;
        NodeData.CurrentID = nextNode.id;
        DestoryButton();
        NextNode();
    }
    public void C_Button_Next()
    {
        if (nextNode.GetPort(fieldName: ("c_exit")).Connection == null)
        {
            nextNode = null;
            return;
        }
        nextNode = nextNode.GetPort(fieldName: ("c_exit")).Connection.node as BaseNode;
        NodeData.CurrentID = nextNode.id;
        DestoryButton();
        NextNode();

    }
    public void DestoryButton()
     {
        foreach (GameObject item in ButtonList)
        {
            Destroy(item);
           
        } 
            is_a_Instance = false;
            is_b_Instance = false;
            is_c_Instance= false;

    }
        
}
